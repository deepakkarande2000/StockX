using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using StockXExceptionLogger;

namespace StokXDAL
{
    public class SqlDbHelper : IDisposable
    {
        #region Members

        private static SqlDbHelper ObjClsSqlDbHelper;
        private SqlDatabase ObjPriDatabase;
        private SqlDatabase ObjPriCommonDb;
        private SqlDatabase ObjPriTransactionDb;
        private SqlDatabase ObjPriQFileDb;

        public static string ConnectionString;
        #endregion

        #region Database Enums
        public enum EnDatabaseCategory { COMMON, POSMSDE, POSQfile };
        #endregion

        #region Constructor and Instance Object

        public static SqlDbHelper Instance()
        {
            if (ObjClsSqlDbHelper == null)
            {
                ObjClsSqlDbHelper = new SqlDbHelper();
            }
            return ObjClsSqlDbHelper;
        }

        private SqlDatabase FunGetDatabaseObject(EnDatabaseCategory EnLocDbCatg)
        {
            if (EnLocDbCatg == EnDatabaseCategory.COMMON)
            {
                if (ObjPriCommonDb == null)
                {
                    ObjPriCommonDb = new SqlDatabase(ConnectionString);
                }
                return ObjPriCommonDb;
            }
            else if (EnLocDbCatg == EnDatabaseCategory.POSMSDE)
            {
                if (ObjPriTransactionDb == null)
                {
                    ObjPriTransactionDb = new SqlDatabase("Data Source=.;Initial Catalog=POSQFile;Integrated Security=True");
                }
                return ObjPriTransactionDb;
            }
            else if (EnLocDbCatg == EnDatabaseCategory.POSQfile)
            {
                if (ObjPriQFileDb == null)
                {
                    ObjPriQFileDb = new SqlDatabase("Data Source=.;Initial Catalog=POSQFile;Integrated Security=True");
                }
                return ObjPriQFileDb;
            }
            else
            {
                return null;
            }
        }

        private DbConnection FunGetDatabaseConnection(EnDatabaseCategory EnLocDbCategory)
        {
            System.Data.Common.DbConnection ObjLocConnection = null;
            if (EnLocDbCategory == EnDatabaseCategory.COMMON)
            {
                ObjLocConnection = ObjPriCommonDb.CreateConnection();
                return ObjLocConnection;
            }
            else if (EnLocDbCategory == EnDatabaseCategory.POSMSDE)
            {
                ObjLocConnection = ObjPriTransactionDb.CreateConnection();
                return ObjLocConnection;
            }
            else if (EnLocDbCategory == EnDatabaseCategory.POSQfile)
            {
                ObjLocConnection = ObjPriQFileDb.CreateConnection();
                return ObjLocConnection;
            }
            else
            {
                return null;
            }
        }

        #endregion


        #region ExecuteDataSet functions
        public DataSet FunExecuteDataSet(EnDatabaseCategory EnLocDbCategory, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                DataSet ObjLocDs = ObjPriDatabase.ExecuteDataSet(CmdTypeLocCommandType, StrLocCommandText);
                ObjLocDs.EnforceConstraints = false;
                return ObjLocDs;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }


        public DataSet FunExecuteDataSetWithoutTimeOut(EnDatabaseCategory EnLocDbCategory, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                DbCommand ObjLocCommand = ObjPriDatabase.GetSqlStringCommand(StrLocCommandText);
                ObjLocCommand.CommandTimeout = 1000;
                DataSet ObjLocDs = ObjPriDatabase.ExecuteDataSet(ObjLocCommand);
                ObjLocDs.EnforceConstraints = false;
                return ObjLocDs;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        public DataSet FunExecuteDataSet(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                DataSet ObjLocDs = ObjPriDatabase.ExecuteDataSet(TransLocTransaction, CmdTypeLocCommandType, StrLocCommandText);
                ObjLocDs.EnforceConstraints = false;
                return ObjLocDs;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        public DataSet FunExecuteDataSet(string storedProcedureName, params object[] parameterValues)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(SqlDbHelper.EnDatabaseCategory.COMMON);
                DataSet ObjLocDs = ObjPriDatabase.ExecuteDataSet(storedProcedureName, parameterValues);
                ObjLocDs.EnforceConstraints = false;
                return ObjLocDs;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        public DataSet FunExecuteDataSet(string storedProcedureName)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(SqlDbHelper.EnDatabaseCategory.COMMON);
                DataSet ObjLocDs = ObjPriDatabase.ExecuteDataSet(storedProcedureName);
                ObjLocDs.EnforceConstraints = false;
                return ObjLocDs;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }


        public DataSet FunExecuteDataSet(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, string StrLocStoredProcedureName, params object[] ObjLocParamArray)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                DataSet ObjLocDs = ObjPriDatabase.ExecuteDataSet(TransLocTransaction, StrLocStoredProcedureName, ObjLocParamArray);
                ObjLocDs.EnforceConstraints = false;
                return ObjLocDs;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        #endregion

        #region ExecuteNonQuery functions

        //This function is used to execute query to insert or update values
        public int FunExecuteNonQuery(EnDatabaseCategory EnLocDbCategory, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(SqlDbHelper.EnDatabaseCategory.COMMON);

                int IntLocReturn = ObjPriDatabase.ExecuteNonQuery(CmdTypeLocCommandType, StrLocCommandText);

                return IntLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return 0;
            }
        }

        //This function is used to execute query to insert or update values
        public int FunExecuteNonQuery(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);


                int IntLocReturn = ObjPriDatabase.ExecuteNonQuery(TransLocTransaction, CmdTypeLocCommandType, StrLocCommandText);


                return IntLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return 0;
            }
        }

        //This function is used to execute query to insert or update values
        public int FunExecuteNonQuery(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, string StrLocStoredProcedureName, params object[] ObjLocParamArray)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);


                int IntLocReturn = ObjPriDatabase.ExecuteNonQuery(TransLocTransaction, StrLocStoredProcedureName, ObjLocParamArray);
                return IntLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return 0;
            }
        }

        //This function is used to execute query to insert or update values

        public int FunExecuteNonQuery(EnDatabaseCategory EnLocDbCategory, string StrLocStoredProcedureName, params object[] ObjLocParamArray)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(SqlDbHelper.EnDatabaseCategory.COMMON);
                //ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);

                int ObjLocReturn = ObjPriDatabase.ExecuteNonQuery(StrLocStoredProcedureName, ObjLocParamArray);
                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return 0;
            }
        }

        #region Method For Settings
        public void SaveSettings(string StoredProcedureName, DataTable dtSettings)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tblSettingsType", dtSettings);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex);
                ExceptionLogger.WriteExceptionLog(ex);
            }
        }

        public void SaveSelectedReports(string StoredProcedureName, DataTable dtReports)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tblLastReportsType", dtReports);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex);
                ExceptionLogger.WriteExceptionLog(ex);
            }
        }

        //public void SaveRights(string StoredProcedureName, DataTable dtSettings)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(StoredProcedureName, con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@tblUserDesignationRightsType", dtSettings);
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ////Logger.LogError(ex);
        //       ExceptionLogger.WriteExceptionLog(ex);
        //    }
        //}


        #endregion

        public int FunExecuteNonQuery(EnDatabaseCategory EnLocDbCategory, string StrLocStoredProcedureName)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(SqlDbHelper.EnDatabaseCategory.COMMON);
                //ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);

                int ObjLocReturn = ObjPriDatabase.ExecuteNonQuery(StrLocStoredProcedureName);
                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return 0;
            }
        }

        public int FunExecuteNonQuery(string StrLocStoredProcedureName, params object[] ObjLocParamArray)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(SqlDbHelper.EnDatabaseCategory.COMMON);
                //ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);

                int ObjLocReturn = ObjPriDatabase.ExecuteNonQuery(StrLocStoredProcedureName, ObjLocParamArray);
                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return 0;
            }
        }

        //This function is used to get dataset without getting timed out.
        public int FunExecuteNonQueryWithoutTimeOut(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                DbCommand ObjLocCommand = ObjPriDatabase.GetSqlStringCommand(StrLocCommandText);
                ObjLocCommand.CommandTimeout = 1000;
                int IntLocReturn = ObjPriDatabase.ExecuteNonQuery(ObjLocCommand, TransLocTransaction);
                return IntLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return 0;
            }
        }

        #endregion

        #region ExecuteReader Functions

        //This function is used to execute query to read values
        public IDataReader FunExecuteReader(EnDatabaseCategory EnLocDbCategory, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);


                IDataReader ObjLocReturn = ObjPriDatabase.ExecuteReader(CmdTypeLocCommandType, StrLocCommandText);


                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError); return null;
            }
        }

        //This function is used to execute query to read values
        public IDataReader FunExecuteReader(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);


                IDataReader ObjLocReturn = ObjPriDatabase.ExecuteReader(TransLocTransaction, CmdTypeLocCommandType, StrLocCommandText);


                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        //This function is used to execute query to read values
        public IDataReader FunExecuteReader(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, string StrLocStoredProcedureName, params object[] ObjLocParamArray)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);


                IDataReader ObjLocReturn = ObjPriDatabase.ExecuteReader(TransLocTransaction, StrLocStoredProcedureName, ObjLocParamArray);
                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }



        //This function is used to execute query to read values
        public IDataReader FunExecuteReader(EnDatabaseCategory EnLocDbCategory, string StrLocStoredProcedureName, params object[] ObjLocParamArray)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);


                IDataReader ObjLocReturn = ObjPriDatabase.ExecuteReader(StrLocStoredProcedureName, ObjLocParamArray);
                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        #endregion

        #region ExecuteScalar Functions
        //This function is used to execute query to retrieve single cell values
        public object FunExecuteScalar(EnDatabaseCategory EnLocDbCategory, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                object ObjLocReturn = ObjPriDatabase.ExecuteScalar(CmdTypeLocCommandType, StrLocCommandText);
                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        //This function is used to execute query to retrieve single cell values
        public object FunExecuteScalar(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, CommandType CmdTypeLocCommandType, string StrLocCommandText)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);


                object ObjLocReturn = ObjPriDatabase.ExecuteScalar(TransLocTransaction, CmdTypeLocCommandType, StrLocCommandText);


                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        //This function is used to execute query to retrieve single cell values
        public object FunExecuteScalar(EnDatabaseCategory EnLocDbCategory, DbTransaction TransLocTransaction, string StrLocStoredProcedureName, params object[] ObjLocParamArray)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                object ObjLocReturn = ObjPriDatabase.ExecuteScalar(TransLocTransaction, StrLocStoredProcedureName, ObjLocParamArray);
                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        //This function is used to execute query to retrieve single cell values
        public object FunExecuteScalar(EnDatabaseCategory EnLocDbCategory, string StrLocStoredProcedureName, params object[] ObjLocParamArray)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                object ObjLocReturn = ObjPriDatabase.ExecuteScalar(StrLocStoredProcedureName, ObjLocParamArray);
                return ObjLocReturn;
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        #endregion

        #region Update Dataset
        //This function is used to update dataset to table
        public object FunUpdateDataset(EnDatabaseCategory EnLocDbCategory, DbTransaction ObjLocTrans, DataTable ObjLocDt, string StrLocStoredProcedureName)
        {
            try
            {
                ObjPriDatabase = FunGetDatabaseObject(EnLocDbCategory);
                DataSet ObjLocDs = new DataSet();
                ObjLocDt.TableName = "UpdatingTable";
                ObjLocDs.Tables.Add(ObjLocDt);
                DbCommand ObjLocCmd = ObjPriDatabase.GetStoredProcCommand(StrLocStoredProcedureName);
                return ObjPriDatabase.UpdateDataSet(ObjLocDs, "UpdatingTable", ObjLocCmd, null, null, ObjLocTrans);
            }
            catch (Exception ObjLocError)
            {
                ExceptionLogger.WriteExceptionLog(ObjLocError);
                return null;
            }
        }

        #endregion

        #region Mis Dispose
        public void FunDispose()
        {
            Dispose();
        }

        // To detect redundant calls
        private bool disposedValue = false;

        // IDisposable
        public void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: free other state (managed objects).
                    ObjPriCommonDb = null;
                    ObjPriTransactionDb = null;
                    ObjPriQFileDb = null;
                    ObjPriDatabase = null;
                }

                // TODO: free your own state (unmanaged objects).
                // TODO: set large fields to null.
            }
            this.disposedValue = true;
        }
        #endregion

        #region IDisposable Support
        // This code added by Visual Basic to correctly implement the disposable pattern.
        private void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
