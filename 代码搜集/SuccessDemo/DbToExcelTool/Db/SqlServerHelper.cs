﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DbToExcelTool.Db
{
    public class SqlServerHelper
    {
        public SqlServerHelper()
        {

        }

        #region ExecuteNonQuery 
        //执行SQL语句，返回影响的记录数 
        /// <summary> 
        /// 执行SQL语句，返回影响的记录数 
        /// </summary> 
        /// <param name="SQLString">SQL语句</param> 
        /// <returns>影响的记录数</returns> 
        public static int ExecuteNonQuery(string SQLString)
        {
            using (var connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                using (var cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary> 
        /// 执行SQL语句，返回影响的记录数 
        /// </summary> 
        /// <param name="SQLString">SQL语句</param> 
        /// <returns>影响的记录数</returns> 
        public static int ExecuteNonQuery(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary> 
        /// 执行SQL语句，返回影响的记录数 
        /// </summary> 
        /// <param name="SQLString">SQL语句</param>
        /// <param name="outParaAction">结果处理委托</param>
        /// <returns>影响的记录数</returns> 
        public static List<string> ExecuteNonQueryOutValue(string SQLString, Action<SqlCommand, List<string>> outParaAction, params SqlParameter[] cmdParms)
        {
            List<string> outValues = new List<string>();
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        int rows = cmd.ExecuteNonQuery();
                        outParaAction(cmd, outValues);
                        cmd.Parameters.Clear();
                        return outValues;
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        //执行多条SQL语句，实现数据库事务。 
        /// <summary> 
        /// 执行多条SQL语句，实现数据库事务。 
        /// </summary> 
        /// <param name="SQLStringList">多条SQL语句</param> 
        public static bool ExecuteNoQueryTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            PrepareCommand(cmd, conn, tx, strsql, null);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    return false;
                }
            }
        }
        #endregion
        #region ExecuteScalar 
        /// <summary> 
        /// 执行一条计算查询结果语句，返回查询结果（object）。 
        /// </summary> 
        /// <param name="SQLString">计算查询结果语句</param> 
        /// <returns>查询结果（object）</returns> 
        public static object ExecuteScalar(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary> 
        /// 执行一条计算查询结果语句，返回查询结果（object）。 
        /// </summary> 
        /// <param name="SQLString">计算查询结果语句</param> 
        /// <returns>查询结果（object）</returns> 
        public static object ExecuteScalar(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        #endregion
        #region ExecuteReader 
        /// <summary> 
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close ) 
        /// </summary> 
        /// <param name="strSQL">查询语句</param> 
        /// <returns>SqlDataReader</returns> 
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return Reader;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        /// <summary> 
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close ) 
        /// </summary> 
        /// <param name="strSQL">查询语句</param> 
        /// <returns>SqlDataReader</returns> 
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return Reader;
            }
            catch (SqlException e)
            {
                throw e;
            }
            // finally 
            // { 
            // cmd.Dispose(); 
            // connection.Close(); 
            // } 
        }
        #endregion
        #region ExecuteDataTable 
        /// <summary> 
        /// 执行查询语句，返回DataTable 
        /// </summary> 
        /// <param name="SQLString">查询语句</param> 
        /// <returns>DataTable</returns> 
        public static DataTable ExecuteDataTable(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
        /// <summary> 
        /// 执行查询语句，返回DataSet 
        /// </summary> 
        /// <param name="SQLString">查询语句</param> 
        /// <returns>DataTable</returns> 
        public static DataTable ExecuteDataTable(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds.Tables[0];
                }
            }
        }
        //获取起始页码和结束页码 
        public static DataTable ExecuteDataTable(string cmdText, int startResord, int maxRecord)
        {
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(cmdText, connection);
                    command.Fill(ds, startResord, maxRecord, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
        #endregion

        #region
        public static DataSet ExecuteDataSet(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary> 
        /// 执行查询语句，返回DataSet 
        /// </summary> 
        /// <param name="SQLString">查询语句</param> 
        /// <returns>DataTable</returns> 
        public static DataSet ExecuteDataSet(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(StaticUnit.DB_CONNECT))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        #endregion
        /// <summary> 
        /// 获取分页数据 在不用存储过程情况下 
        /// </summary> 
        /// <param name="recordCount">总记录条数</param> 
        /// <param name="selectList">选择的列逗号隔开,支持top num</param> 
        /// <param name="tableName">表名字</param> 
        /// <param name="whereStr">条件字符 必须前加 and</param> 
        /// <param name="orderExpression">排序 例如 ID</param> 
        /// <param name="pageIdex">当前索引页</param> 
        /// <param name="pageSize">每页记录数</param> 
        /// <returns></returns> 
        public static DataTable getPager(out int recordCount, string selectList, string tableName, string whereStr, string orderExpression, int pageIdex, int pageSize)
        {
            int rows = 0;
            DataTable dt = new DataTable();
            MatchCollection matchs = Regex.Matches(selectList, @"top\s+\d{1,}", RegexOptions.IgnoreCase);//含有top 
            string sqlStr = sqlStr = string.Format("select {0} from {1} where 1=1 {2}", selectList, tableName, whereStr);
            if (!string.IsNullOrEmpty(orderExpression)) { sqlStr += string.Format(" Order by {0}", orderExpression); }
            if (matchs.Count > 0) //含有top的时候 
            {
                DataTable dtTemp = ExecuteDataTable(sqlStr);
                rows = dtTemp.Rows.Count;
            }
            else //不含有top的时候 
            {
                string sqlCount = string.Format("select count(*) from {0} where 1=1 {1} ", tableName, whereStr);
                //获取行数 
                object obj = ExecuteScalar(sqlCount);
                if (obj != null)
                {
                    rows = Convert.ToInt32(obj);
                }
            }
            dt = ExecuteDataTable(sqlStr, (pageIdex - 1) * pageSize, pageSize);
            recordCount = rows;
            return dt;
        }
        #region 创建command 
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType; 
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion
    }
}
