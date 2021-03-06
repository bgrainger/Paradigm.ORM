﻿using Paradigm.ORM.Data.Attributes;
using Paradigm.ORM.Data.Database.Schema.Structure;

namespace Paradigm.ORM.Data.Cassandra.Schema.Structure
{
    /// <summary>
    /// Provides a database constraint schema.
    /// </summary>
    /// <seealso cref="IConstraint" />
    [Table("columns", Catalog = "system_schema")]
    public class CqlConstraint: IConstraint
    {
        /// <summary>
        /// Gets the name of the constraint.
        /// </summary>
        [Column("type", "text")]
        public string ColumnType { get; set; }

        /// <summary>
        /// Gets the name of the constraint.
        /// </summary>
        [Column("column_name", "text")]
        public string Name { get; set; }

        /// <summary>
        /// Gets the name of the catalog where the parent table resides.
        /// </summary>
        [Column("keyspace_name", "text")]
        public string CatalogName { get; set; }

        /// <summary>
        /// Gets the name of the source table of the constraint.
        /// </summary>
        [Column("table_name", "text")]
        public string FromTableName { get; set; }

        /// <summary>
        /// Gets or sets the kind of the column.
        /// </summary>
        /// <value>
        /// The kind of the column.
        /// </value>
        [Column("kind", "text")]
        public string ColumnKind { get; set; }

        /// <summary>
        /// Gets the name of the source column of the constraint.
        /// </summary>
        public string FromColumnName { get; set; }

        /// <summary>
        /// Gets the type of the constraint.
        /// </summary>
        public ConstraintType Type { get; set; }

        /// <summary>
        /// Gets the name of the schema where the parent table resides.
        /// </summary>
        public string SchemaName { get; set; }

        /// <summary>
        /// Gets the name of the referenced table name.
        /// </summary>
        public string ToTableName { get; set; }

        /// <summary>
        /// Gets the name of the referenced table column.
        /// </summary>
        public string ToColumnName { get; set; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Constraint [{this.FromTableName}].[{this.Name}]";
    }
}