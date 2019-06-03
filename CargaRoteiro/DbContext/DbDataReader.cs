using System.Data;
using System.Data.SqlClient;

namespace Wiki
{
    public class DbDataAdapter : IDataAdapter
    {
        private readonly IDataAdapter _dataAdapter;

        public DbDataAdapter()
        {
            _dataAdapter = new SqlDataAdapter();
        }

        public MissingMappingAction MissingMappingAction { get => _dataAdapter.MissingMappingAction; set => _dataAdapter.MissingMappingAction = value; }
        public MissingSchemaAction MissingSchemaAction { get => _dataAdapter.MissingSchemaAction; set => _dataAdapter.MissingSchemaAction = value; }

        public ITableMappingCollection TableMappings => _dataAdapter.TableMappings;

        public int Fill(DataSet dataSet)
        {
            return _dataAdapter.Fill(dataSet);
        }

        public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            return _dataAdapter.FillSchema(dataSet, schemaType);
        }

        public IDataParameter[] GetFillParameters()
        {
            return _dataAdapter.GetFillParameters();
        }

        public int Update(DataSet dataSet)
        {
            return _dataAdapter.Update(dataSet);
        }
    }
}
