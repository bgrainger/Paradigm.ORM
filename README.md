[![Build Status](https://travis-ci.org/MiracleDevs/Paradigm.ORM.svg?branch=master)](https://travis-ci.org/MiracleDevs/Paradigm.ORM)


| Library    | Nuget | Install
|-|-|-|
| Data       | [![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](https://www.nuget.org/packages/Paradigm.ORM.Data/)            | `Install-Package Paradigm.ORM.Data` |
| MySql      | [![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](https://www.nuget.org/packages/Paradigm.ORM.Data.MySql/)      | `Install-Package Paradigm.ORM.Data.MySql` |
| PostgreSQL | [![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](https://www.nuget.org/packages/Paradigm.ORM.Data.PostgreSql/) | `Install-Package Paradigm.ORM.Data.PostgreSql` |
| SQL Server | [![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](https://www.nuget.org/packages/Paradigm.ORM.Data.SqlServer/)  | `Install-Package Paradigm.ORM.Data.SqlServer` |
| Cassandra | [![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](https://www.nuget.org/packages/Paradigm.ORM.Data.Cassandra/)  | `Install-Package Paradigm.ORM.Data.Cassandra` |

# Paradigm.ORM
.NET Core ORM with dbfirst support, and code scaffolding features. This ORM supports different database sources.


Self Contained Deploy (SCD)
---

Bellow you can find portable versions for all major OSs.
If you are planning to use the tools in several projects, we recommend to add the SCD folder to your PATH.

| Tool | OS | Zip File |
|-|-|-|
| DbFirst | Windows x86 | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dbfirst.win-x86.zip) |
| DbFirst | Windows x64 | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dbfirst.win-x64.zip) |
| DbFirst | Linux x64   | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dbfirst.linux-x64.zip) |
| DbFirst | OSX x64     | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dbfirst.osx-x64.zip) |
||||
| DbPublisher | Windows x86 | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dbpublisher.win-x86.zip) |
| DbPublisher | Windows x64 | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dbpublisher.win-x64.zip) |
| DbPublisher | Linux x64   | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dbpublisher.linux-x64.zip) |
| DbPublisher | OSX x64     | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dbpublisher.osx-x64.zip) |
||||
| DataExport | Windows x86 | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dataexport.win-x86.zip) |
| DataExport | Windows x64 | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dataexport.win-x64.zip) |
| DataExport | Linux x64   | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dataexport.linux-x64.zip) |
| DataExport | OSX x64     | [Download](https://github.com/MiracleDevs/Paradigm.ORM/releases/download/v2.3.1/dataexport.osx-x64.zip) |

Change log
---

Version `2.3.2`
- Updated nuget dependencies.
- Added logging provider and a default logger to log commands and command errors.

Version `2.3.1`
- Added more tests for composite partition keys for cassandra/scylla connector.
- Disabled the batch delete for cassandra/scylla due to cql constrains.
- Fixed delete query for cassandra/scylla connector.
- Updated nuget dependencies.


Version `2.3.0`
- Upgraded the cql schema provider, to use the newer scylla "system_schema" keyspace.
- Updated nuget dependencies.
- Updated test cases.


Version `2.2.4`
- Added visual basic tests.
- Updated nuget dependencies.
- Fixed a couple of bugs found with the vb tests.


Version `2.2.3`
- Added new DatabaseCommandException thrown when executing database commands. The DatabaseCommandException contains a reference to the
  executing command, allowing for a better debugging experience.
  Use Command.CommandText to observe the sql or cql query being executed.
  Use Command.Parameters to observe the parameters bound to the query.
- Fixed a bug in Cassandra connector not adding a parameter in one of the AddParameters methods.
- Fixed a bug in CustomQuery sync execution not updated the command text after parameter replacement.
- Improved and updated tests.


Version `2.2.2`
- Removed mandatory data type in ColumnAttribute. The orm will choose the default column types for each database type.
- Changed how the CommandBatch replace parameter names, to prevent name collision.
- Added tests for the command batch name replacement.
- Changed how select parameters are replaced, from @Index to  @pIndex or :pIndex, depending on the database parameter naming conventions.
- Updated NuGet dependencies.


Version `2.2.1`
- Added a cache service for descriptors all over the orm, to prevent tons of small objects filling the heap.
- Removed constructors receiving descriptors. Now all the ORM classes should refer to the cache for descriptors.
- Descriptor constructors are now internal and can not be instantiated outside the ORM.


Version `2.2.0`
- Refactor command handling to allow parallel execution of the ORM without conflicting with some of the
  connectors. The orm does not cache a command inside the command builder any more.
- Refactor command builders and moved shared functionality to the core classes, and removed the
  duplication from the client implementations. Now will be even easier to implement new clients.
- Moved base protected methods from the CommandBuilderBase to the ICommandFormatProvider and added a new
  base CommandFormatProviderBase with shared behavior for all the different format providers.
- Removed IDisposable interface from most of the ORM core classes. The most notable are:
  - Database access
  - Query
  - Custom query
  - All the stored procedure types
  - Schema Provider
- Removed extension methods for the IDatabaseConnector not used any more.


Version `2.1.7`
- Changed how the DatabaseAccess classes utilize the BatchManager to be thread safe.


Version `2.1.6`
- Updated Paradigm.Core and other dependencies.
- Published new versions for the tools.


Version `2.1.5`
- Removed a dependency over generic entities that needed a parameterless constructor
  in all the solution.


Version `2.1.4`
- Removed a dependency over generic entities that needed a parameterless constructor.


Version `2.1.3`
- Added new constructor to `DatabaseReaderMapper` to allow set both the service provider and the
  database connector. This will allow multi-tenancy support using the dbfirst generated code.
- Added new constructors to all the stored procedure types for the same reason as the previous point.
- Added missing ValueConverter inside the database reader value provider.


Version `2.1.2`
- Changed the database reader mappers to work with the `IServiceProvider` class. Now, will try to instantiate
  the entities with the service provider first, and if the service provider can't, will use the activator to
  create a new instance. This will allow the Paradigm.Services framework to fully delegate the instancing to
  DI allowing better DDD.


Version `2.1.1`
- Fixed a problem in cassandra connector where the schema provider can not guess the column type when the column is a
  clustering key with order applied to it.
- Made the modifications to the tests to test the above problem.


Version `2.1.0`
- Added a new Cassandra connector.
  This new connector allows to work against Apache Cassandra o ScyllaDB. There are some limitations imposed by the
  DataStax connector, and other imposed by the orm, but for most cases will be just fine.
> Warning: The ORM will work with column families that mimic sql tables, aka. without lists, maps, or other not standard
> relational databases. Even if Cassandra does not supports joins, the ORM allows to create virtual foreign keys between tables
> and create navigation properties from it.
- Data Export, DbFirst and DbPublisher can work now against Cassandra and ScyllaDB.
- In all the configuration files, now the Database Type changed to Upper Camel Case syntax, the database types are:
    - SqlServer,
    - MySql,
    - PostgreSql,
    - Cassandra
- Updated MySql Connector version.


Version `2.0.1`
- Updated Paradigm.Core to version `2.0.1`.


Version `2.0.0`
- Updated .net core from version 1 to version 2.


Version `1.0.0`
- Uploaded first version of the Paradigm ORM.
