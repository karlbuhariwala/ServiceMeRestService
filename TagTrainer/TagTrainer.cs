
namespace TagTrainer
{
    using RestServiceV1.Providers;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Json;
    using System.Windows.Forms;

    public partial class TagTrainer : Form
    {
        private const string FileVersion = "1.0";
        private const string SoftwareVersion = "1.0";
        private const string FileName = "TestData.txt";

        private static Dictionary<string, List<string>> keywordToTagMap;

        private static DataContainer dataContainer;

        public TagTrainer()
        {
            InitializeComponent();
            dataContainer = new DataContainer();
            dataContainer.Version = TagTrainer.FileVersion;
            dataContainer.tagToSentenceMap = new Dictionary<string, Tuple<List<string>, List<string>>>();

            softwareVersionLabel.Text = TagTrainer.SoftwareVersion;
            this.LoadFromFile();
        }

        #region Control action handlers
        private void createButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(createTagTextBox.Text))
            {
                this.CreateANewTag(createTagTextBox.Text);
                createTagTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("No tag name");
            }
        }

        private void tagComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tagComboBox.SelectedItem != null && TagTrainer.dataContainer.tagToSentenceMap.ContainsKey(tagComboBox.SelectedItem.ToString()))
            {
                List<string> sentences = TagTrainer.dataContainer.tagToSentenceMap[tagComboBox.SelectedItem.ToString()].Item1;
                statement1TextBox.Text = sentences[0];
                statement2TextBox.Text = sentences[1];
                statement3TextBox.Text = sentences[2];
                statement4TextBox.Text = sentences[3];
                statement5TextBox.Text = sentences[4];
                statement6TextBox.Text = sentences[5];
                statement7TextBox.Text = sentences[6];
                statement8TextBox.Text = sentences[7];
                statement9TextBox.Text = sentences[8];
                statement10TextBox.Text = sentences[9];

                List<string> keywords = TagTrainer.dataContainer.tagToSentenceMap[tagComboBox.SelectedItem.ToString()].Item2;
                keywordsLabel.Text = string.Join(",", keywords);
            }
            else
            {
                MessageBox.Show("No tag entry present for tag called " + tagComboBox.SelectedItem);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (tagComboBox.SelectedItem != null && TagTrainer.dataContainer.tagToSentenceMap.ContainsKey(tagComboBox.SelectedItem.ToString()))
            {
                List<string> sentences = new List<string>();
                sentences.Add(statement1TextBox.Text);
                sentences.Add(statement2TextBox.Text);
                sentences.Add(statement3TextBox.Text);
                sentences.Add(statement4TextBox.Text);
                sentences.Add(statement5TextBox.Text);
                sentences.Add(statement6TextBox.Text);
                sentences.Add(statement7TextBox.Text);
                sentences.Add(statement8TextBox.Text);
                sentences.Add(statement9TextBox.Text);
                sentences.Add(statement10TextBox.Text);

                // Todo: Do this.
                INlpProvider nlpProvider = (INlpProvider)ProviderFactory.Instance.CreateProvider<INlpProvider>(null);
                List<string> keywords = new List<string>();
                foreach (string sentence in sentences)
                {
                    foreach (var item in nlpProvider.GetRelevantTerms(sentence))
                    {
                        keywords.AddRange(item.Value);
                    }
                }

                TagTrainer.dataContainer.tagToSentenceMap[tagComboBox.SelectedItem.ToString()] = new Tuple<List<string>, List<string>>(sentences, keywords);
                this.SaveToFile();

                TagTrainer.keywordToTagMap = null;
                keywordsLabel.Text = string.Join(",", keywords);

                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("No tag entry present for tag called " + tagComboBox.SelectedItem);
            }
        }

        private void generateTagsButton_Click(object sender, EventArgs e)
        {
            if (TagTrainer.keywordToTagMap == null)
            {
                TagTrainer.keywordToTagMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
                foreach (string tag in TagTrainer.dataContainer.tagToSentenceMap.Keys)
                {
                    List<string> keywords = TagTrainer.dataContainer.tagToSentenceMap[tag].Item2;
                    foreach (string keyword in keywords)
                    {
                        List<string> tagsList;
                        if (TagTrainer.keywordToTagMap.ContainsKey(keyword))
                        {
                            tagsList = TagTrainer.keywordToTagMap[keyword];
                        }
                        else
                        {
                            tagsList = new List<string>();
                            TagTrainer.keywordToTagMap.Add(keyword, tagsList);
                        }

                        tagsList.Add(tag);
                    }
                }
            }

            // Todo: do this
            INlpProvider nlpProvider = (INlpProvider)ProviderFactory.Instance.CreateProvider<INlpProvider>(null);
            List<string> sentenceKeywords = new List<string>();
            foreach (var item in nlpProvider.GetRelevantTerms(testTagTextBox.Text))
            {
                sentenceKeywords.AddRange(item.Value);
            }

            Dictionary<string, int> tagHitCount = new Dictionary<string, int>();
            foreach (string keyword in sentenceKeywords)
            {
                if (TagTrainer.keywordToTagMap.ContainsKey(keyword))
                {
                    foreach (string tag in TagTrainer.keywordToTagMap[keyword])
                    {
                        if (tagHitCount.ContainsKey(tag))
                        {
                            tagHitCount[tag] += 1;
                        }
                        else
                        {
                            tagHitCount.Add(tag, 1);
                        }
                    }
                }
            }

            List<string> suggestedTags = tagHitCount.ToList().OrderByDescending(x => x.Value).Take(5).Select(x => x.Key).ToList();
            tagsLabel.Text = string.Join(",", suggestedTags);
        } 
        #endregion

        #region Input output operations
        private void SaveToFile()
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(TagTrainer.FileName, FileMode.Create);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataContainer));
                serializer.WriteObject(fileStream, TagTrainer.dataContainer);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        private void LoadFromFile()
        {
            if (File.Exists(TagTrainer.FileName))
            {
                FileStream fileStream = null;
                try
                {
                    fileStream = new FileStream(TagTrainer.FileName, FileMode.Open);
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataContainer));
                    TagTrainer.dataContainer = (DataContainer)serializer.ReadObject(fileStream);

                    tagComboBox.Items.Clear();
                    foreach (string key in TagTrainer.dataContainer.tagToSentenceMap.Keys)
                    {
                        tagComboBox.Items.Add(key);
                    }

                    fileNameLabel.Text = new FileInfo(TagTrainer.FileName).FullName;
                    fileVersionLabel.Text = TagTrainer.dataContainer.Version;
                }
                finally
                {
                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No file found named " + TagTrainer.FileName);
            }
        } 
        #endregion

        #region Helpers
        private void CreateANewTag(string tag)
        {
            if (!TagTrainer.dataContainer.tagToSentenceMap.ContainsKey(tag))
            {
                List<string> sentences = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    sentences.Add(string.Empty);
                }

                TagTrainer.dataContainer.tagToSentenceMap.Add(tag, new Tuple<List<string>, List<string>>(sentences, new List<string>()));


                this.SaveToFile();
                this.LoadFromFile();

                tagComboBox.SelectedIndex = tagComboBox.Items.Count - 1;
            }
            else
            {
                MessageBox.Show(string.Format("Tag named {0} already exists.", tag));
            }
        } 
        #endregion
    }

    public class DataContainer
    {
        public Dictionary<string, Tuple<List<string>, List<string>>> tagToSentenceMap { get; set; }

        public string Version { get; set; }
    }
}
