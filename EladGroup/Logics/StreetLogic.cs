using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EladGroup.Models;

namespace EladGroup.Logics
{
    internal class StreetLogic : SharedLogic<Street>
    {
        private const int StreetNameMaxCharCount = 50;
        
        /// <summary>
        /// Inserts a new <see cref="Street"/> entity to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <param name="cityId"></param>
        /// <exception cref="Exception">In case `Street.Name`'s length is too long.</exception>
        /// <see cref="StreetNameMaxCharCount"/>
        public void Insert(string name, int priority, int cityId)
        {
            if (name.Length > StreetNameMaxCharCount)
            {
                throw new Exception("`Street.Name`'s length is too long");
            }
            
            // TODO: Check if `cityId` is an existing cityId.
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "INSERT INTO Street (Name, Priority, CityId) VALUES ");
            stringBuilder.Append($"(N'{name}', {priority}, {cityId})");

            string query = stringBuilder.ToString();
            RunVoidQuery(query);
        }

        public List<Street> Get()
        {
            return RunListQuery("SELECT * FROM Street");
        }

        protected override Street FillEntry(SqlDataReader reader)
        {
            Street street = new Street();

            Int32.TryParse(reader["Id"].ToString(), out int id);
            street.Id = id;

            street.Name = reader["Name"].ToString();

            Int32.TryParse(reader["Priority"].ToString(), out
                int priority);
            street.Priority = priority;

            Int32.TryParse(reader["CityId"].ToString(), out
                int cityId);
            street.CityId = cityId;

            return street;
        }
    }
}