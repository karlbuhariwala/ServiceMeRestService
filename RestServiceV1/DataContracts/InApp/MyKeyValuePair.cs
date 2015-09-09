// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = MyKeyValuePair.cs

namespace RestServiceV1.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Key value pair with first and second as names.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    [Serializable]
    public struct MyKeyValuePair<TKey, TValue>
    {
        /// <summary>
        /// The first
        /// </summary>
        private TKey first;

        /// <summary>
        /// The second
        /// </summary>
        private TValue second;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyKeyValuePair{TKey, TValue}"/> struct.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public MyKeyValuePair(TKey key, TValue value)
            : this()
        {
            this.first = key;
            this.second = value;
        }

        /// <summary>
        /// Gets or sets the first.
        /// </summary>
        /// <value>
        /// The first.
        /// </value>
        [IgnoreDataMemberAttribute]
        public TKey First
        {
            get { return first; }
            set { first = value; }
        }

        /// <summary>
        /// Gets or sets the second.
        /// </summary>
        /// <value>
        /// The second.
        /// </value>
        [IgnoreDataMemberAttribute]
        public TValue Second
        {
            get { return second; }
            set { second = value; }
        }
    }
}