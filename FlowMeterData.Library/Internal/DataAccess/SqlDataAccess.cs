﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace FlowMeterData.Library.Internal.DataAccess
{
    public class SqlDataAccess : IDisposable, ISqlDataAccess
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public SqlDataAccess(IConfiguration configuration, ILogger<SqlDataAccess> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name);
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure,
                                                    parameters,
                                                    commandType: CommandType.StoredProcedure).ToList();

                return rows;

            }
        }
        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }



        //-----------------------------------------------------------------------------------

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _isClosed = false;
        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            _connection = new SqlConnection(connectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();
            _isClosed = false;
        }
        public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure,
                                                parameters,
                                                commandType: CommandType.StoredProcedure,
                                                transaction: _transaction).ToList();

            return rows;
        }
        public void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            _connection.Execute(storedProcedure,
                                parameters,
                                commandType: CommandType.StoredProcedure,
                                transaction: _transaction);
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();

            _isClosed = true;
        }
        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();

            _isClosed = true;
        }

        public void Dispose()
        {
            if (_isClosed == false)
            {
                try
                {
                    CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"{ex.Message} Something Went Wrong Commiting In The Dispose Method.");
                }
            }

            _transaction = null;
            _connection = null;
        }
    }
}
