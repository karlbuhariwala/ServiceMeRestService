// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = NlpProvider.cs

namespace RestServiceV1.Providers
{
    using edu.stanford.nlp.ling;
    using edu.stanford.nlp.pipeline;
    using edu.stanford.nlp.util;
    using java.util;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Class for the NlpProvider 
    /// </summary>
    public class NlpProvider : INlpProvider
    {
        /// <summary>
        /// The pipeline
        /// </summary>
        private static StanfordCoreNLP pipeline;

        /// <summary>
        /// The relevant position
        /// </summary>
        private static List<string> relevantPos;

        /// <summary>
        /// Initializes a new instance of the <see cref="NlpProvider"/> class.
        /// </summary>
        public NlpProvider()
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            if (pipeline == null)
            {
                // Todo: How to get this ourselves
                //var jarRoot = @"C:\Users\karlbuha\Documents\Visual Studio 2012\Projects\ServiceMe\RestServiceV1\NLPModules\";
                var jarRoot = ConfigurationManager.AppSettings["NlpModulePath"];
                //var jarRoot = @"F:\sitesroot\0\bin\NlpModules\";

                // Annotation pipeline configuration
                var props = new Properties();
                props.setProperty("annotators", "tokenize, ssplit, pos, lemma");
                props.setProperty("sutime.binders", "0");
                props.setProperty("ner.useSUTime", "false");

                // We should change current directory, so StanfordCoreNLP could find all the model files automatically
                var curDir = Environment.CurrentDirectory;
                Directory.SetCurrentDirectory(jarRoot);
                NlpProvider.pipeline = new StanfordCoreNLP(props);
                Directory.SetCurrentDirectory(curDir);

                NlpProvider.relevantPos = ConfigurationManager.AppSettings["NlpFos"].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        /// <summary>
        /// Gets the relevant terms.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        /// IDictionary of types of tokens and values
        /// </returns>
        IDictionary<string, IEnumerable<string>> INlpProvider.GetRelevantTerms(string text)
        {
            IDictionary<string, IEnumerable<string>> returnDictionary = new Dictionary<string, IEnumerable<string>>();
            var annotation = new Annotation(text);
            NlpProvider.pipeline.annotate(annotation);

            var sentences = annotation.get(new CoreAnnotations.SentencesAnnotation().getClass()) as ArrayList;
            foreach (CoreMap sentence in sentences)
            {
                var tokens = sentence.get(new CoreAnnotations.TokensAnnotation().getClass()) as ArrayList;
                foreach (CoreLabel token in tokens)
                {
                    string pos = token.get(new CoreAnnotations.PartOfSpeechAnnotation().getClass()).ToString().ToUpper();
                    if (NlpProvider.relevantPos.Contains(pos))
                    {
                        List<string> listOfValues;
                        if (returnDictionary.ContainsKey(pos))
                        {
                            listOfValues = returnDictionary[pos] as List<string>;
                        }
                        else
                        {
                            listOfValues = new List<string>();
                            returnDictionary.Add(pos, listOfValues);
                        }

                        string word = token.get(new CoreAnnotations.TextAnnotation().getClass()).ToString();
                        listOfValues.Add(word);
                        ////var ner = token.get(new CoreAnnotations.NamedEntityTagAnnotation().getClass());
                        ////var normalizedner = token.get(new CoreAnnotations.NormalizedNamedEntityTagAnnotation().getClass());
                    }
                }
            }

            return returnDictionary;
        }
    }
}