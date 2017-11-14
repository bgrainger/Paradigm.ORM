using System;
using System.Collections.Generic;
using Paradigm.ORM.Data.Database;
using Paradigm.ORM.Data.Descriptors;
using Paradigm.ORM.Data.Exceptions;
using Paradigm.ORM.Data.Extensions;
using Paradigm.ORM.Data.Mappers.Generic;

namespace Paradigm.ORM.Data.StoredProcedures
{
    /// <summary>
    /// Provides the means to execute data reader stored procedures returning only 6 result sets.
    /// </summary>
    /// <remarks>
    /// Instead of sending individual parameters to the procedure, the orm expects a  <see cref="TParameters"/> type
    /// containing or referencing the mapping information, where individual parameters will be mapped to properties.
    /// </remarks>
    /// <typeparam name="TParameters">The type of the parameters.</typeparam>
    /// <typeparam name="TResult1">The type of the first result.</typeparam>
    /// <typeparam name="TResult2">The type of the second result.</typeparam>
    /// <typeparam name="TResult3">The type of the third result.</typeparam>
    /// <typeparam name="TResult4">The type of the fourth result.</typeparam>
    /// <typeparam name="TResult5">The type of the fifth result.</typeparam>
    /// <typeparam name="TResult6">The type of the sixth result.</typeparam>
    /// <seealso cref="Paradigm.ORM.Data.StoredProcedures.StoredProcedureBase{TParameters}" />
    /// <seealso cref="IReaderStoredProcedure{TParameters,TResult1,TResult2,TResult3,TResult4,TResult5,TResult6}" />
    public partial class ReaderStoredProcedure<TParameters, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> : 
        StoredProcedureBase<TParameters>,
        IReaderStoredProcedure<TParameters, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the first result mapper.
        /// </summary>
        private IDatabaseReaderMapper<TResult1> Mapper1 { get; set; }

        /// <summary>
        /// Gets or sets the secund result mapper.
        /// </summary>
        private IDatabaseReaderMapper<TResult2> Mapper2 { get; set; }

        /// <summary>
        /// Gets or sets the third result mapper.
        /// </summary>
        private IDatabaseReaderMapper<TResult3> Mapper3 { get; set; }

        /// <summary>
        /// Gets or sets the fourth result mapper.
        /// </summary>
        private IDatabaseReaderMapper<TResult4> Mapper4 { get; set; }

        /// <summary>
        /// Gets or sets the fifth result mapper.
        /// </summary>
        private IDatabaseReaderMapper<TResult5> Mapper5 { get; set; }

        /// <summary>
        /// Gets or sets the sixth result mapper.
        /// </summary>
        private IDatabaseReaderMapper<TResult6> Mapper6 { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ReaderStoredProcedure.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ReaderStoredProcedure(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReaderStoredProcedure.
        /// </summary>
        /// <param name="connector">The database connector.</param>
        public ReaderStoredProcedure(IDatabaseConnector connector) : base(connector)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReaderStoredProcedure{TParameters, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="connector">The database connector.</param>
        public ReaderStoredProcedure(IServiceProvider serviceProvider, IDatabaseConnector connector) : base(serviceProvider, connector)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReaderStoredProcedure.
        /// </summary>
        /// <param name="connector">The database connector.</param>
        /// <param name="mapper1">The first result mapper.</param>
        /// <param name="mapper2">The second result mapper.</param>
        /// <param name="mapper3">The third result mapper.</param>
        /// <param name="mapper4">The fourth result mapper.</param>
        /// <param name="mapper5">The fifth result mapper.</param>
        /// <param name="mapper6">The sixth result mapper.</param>
        public ReaderStoredProcedure(
            IDatabaseConnector connector, 
            IDatabaseReaderMapper<TResult1> mapper1, 
            IDatabaseReaderMapper<TResult2> mapper2,
            IDatabaseReaderMapper<TResult3> mapper3,
            IDatabaseReaderMapper<TResult4> mapper4,
            IDatabaseReaderMapper<TResult5> mapper5,
            IDatabaseReaderMapper<TResult6> mapper6) : base(connector)
        {
            this.Mapper1 = mapper1;
            this.Mapper2 = mapper2;
            this.Mapper3 = mapper3;
            this.Mapper4 = mapper4;
            this.Mapper5 = mapper5;
            this.Mapper6 = mapper6;
        }

        /// <summary>
        /// Initializes a new instance of the ReaderStoredProcedure.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="connector">The database connector.</param>
        /// <param name="mapper1">The first result mapper.</param>
        /// <param name="mapper2">The second result mapper.</param>
        /// <param name="mapper3">The third result mapper.</param>
        /// <param name="mapper4">The fourth result mapper.</param>
        /// <param name="mapper5">The fifth result mapper.</param>
        /// <param name="mapper6">The sixth result mapper.</param>
        public ReaderStoredProcedure(
            IServiceProvider serviceProvider,
            IDatabaseConnector connector,
            IDatabaseReaderMapper<TResult1> mapper1,
            IDatabaseReaderMapper<TResult2> mapper2,
            IDatabaseReaderMapper<TResult3> mapper3,
            IDatabaseReaderMapper<TResult4> mapper4,
            IDatabaseReaderMapper<TResult5> mapper5,
            IDatabaseReaderMapper<TResult6> mapper6) : base(serviceProvider, connector)
        {
            this.Mapper1 = mapper1;
            this.Mapper2 = mapper2;
            this.Mapper3 = mapper3;
            this.Mapper4 = mapper4;
            this.Mapper5 = mapper5;
            this.Mapper6 = mapper6;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Executes the stored procedure and return a list of tuples.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// List of tuples.
        /// </returns>
        public Tuple<List<TResult1>, List<TResult2>, List<TResult3>, List<TResult4>, List<TResult5>, List<TResult6>> Execute(TParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException("Must give parameters to execute the stored procedure.");

            this.SetParametersValue(parameters);

            using (var reader = this.Command.ExecuteReader())
            {
                var result1 = this.Mapper1.Map(reader);
                reader.NextResult();
                var result2 = this.Mapper2.Map(reader);
                reader.NextResult();
                var result3 = this.Mapper3.Map(reader);
                reader.NextResult();
                var result4 = this.Mapper4.Map(reader);
                reader.NextResult();
                var result5 = this.Mapper5.Map(reader);
                reader.NextResult();
                var result6 = this.Mapper6.Map(reader);

                return new Tuple<List<TResult1>, List<TResult2>, List<TResult3>, List<TResult4>, List<TResult5>, List<TResult6>>(result1, result2, result3, result4, result5, result6);
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes after the initialization.
        /// </summary>
        protected override void AfterInitialize()
        {
            base.AfterInitialize();

            this.Mapper1 = this.Mapper1 ?? this.ServiceProvider.GetServiceIfAvailable<IDatabaseReaderMapper<TResult1>>(() => new DatabaseReaderMapper<TResult1>(this.Connector, new TableTypeDescriptor(typeof(TResult1))));
            this.Mapper2 = this.Mapper2 ?? this.ServiceProvider.GetServiceIfAvailable<IDatabaseReaderMapper<TResult2>>(() => new DatabaseReaderMapper<TResult2>(this.Connector, new TableTypeDescriptor(typeof(TResult2))));
            this.Mapper3 = this.Mapper3 ?? this.ServiceProvider.GetServiceIfAvailable<IDatabaseReaderMapper<TResult3>>(() => new DatabaseReaderMapper<TResult3>(this.Connector, new TableTypeDescriptor(typeof(TResult3))));
            this.Mapper4 = this.Mapper4 ?? this.ServiceProvider.GetServiceIfAvailable<IDatabaseReaderMapper<TResult4>>(() => new DatabaseReaderMapper<TResult4>(this.Connector, new TableTypeDescriptor(typeof(TResult4))));
            this.Mapper5 = this.Mapper5 ?? this.ServiceProvider.GetServiceIfAvailable<IDatabaseReaderMapper<TResult5>>(() => new DatabaseReaderMapper<TResult5>(this.Connector, new TableTypeDescriptor(typeof(TResult5))));
            this.Mapper6 = this.Mapper6 ?? this.ServiceProvider.GetServiceIfAvailable<IDatabaseReaderMapper<TResult6>>(() => new DatabaseReaderMapper<TResult6>(this.Connector, new TableTypeDescriptor(typeof(TResult6))));

            if (this.Mapper1 == null)
                throw new OrmException("The first mapper can not be null.");

            if (this.Mapper2 == null)
                throw new OrmException("The second mapper can not be null.");

            if (this.Mapper3 == null)
                throw new OrmException("The third mapper can not be null.");

            if (this.Mapper4 == null)
                throw new OrmException("The fourth mapper can not be null.");

            if (this.Mapper5 == null)
                throw new OrmException("The fifth mapper can not be null.");

            if (this.Mapper6 == null)
                throw new OrmException("The sixth mapper can not be null.");
        }

        #endregion
    }
}