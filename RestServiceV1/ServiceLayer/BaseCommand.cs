// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = BaseCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;

    /// <summary>
    /// Base command for every command
    /// </summary>
    public abstract class BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCommand"/> class.
        /// </summary>
        public BaseCommand()
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected virtual void Initialize()
        {
        }

        /// <summary>
        /// Called when [validate].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Whether the input params are valid or not</returns>
        public virtual bool OnValidate(RequestContext context)
        {
            return true;
        }

        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Result of the OnExecute</returns>
        public abstract BaseReturnContainer OnExecute(RequestContext context);
    }
}