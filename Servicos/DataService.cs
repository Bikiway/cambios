using cambios.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambios.Servicos
{
    public class DataService
    {
        private SQLiteConnection connection;

        private SQLiteCommand command;

        private DialogService dialogService;

        public DataService()
        {
            dialogService = new DialogService();

            if(!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data"); //Se a pasta não tiver criada, vamos cria-la.
            }

            var path = @"Data\rates.sqlite";

            //Criar a base de dados e a tabela

            try
            {
                connection = new SQLiteConnection("Data Source = " + path);
                connection.Open();

                //string sqlcommand = "Creaate table if not exists rates(RateId int, Code varchar(5), TaxRate real, Name varchar(250))";
                string sqlcommand = "Create table if not exists rates(Country varchar(250), Currency varchar(50), IsoA3Code varchar(250), IsoA2Code varchar(250), Value decimal)";
                command = new SQLiteCommand(sqlcommand, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
        }

        public void SaveData(List<Rate> rates)
        {
            try
            {
                CultureInfo us = CultureInfo.GetCultureInfo("en-US");
                foreach (var rate in rates)
                {
                    string w = string.Format(us, "{0:F}", rate.Value);

                    string sql = string.Format("insert into rates(Country, Currency, IsoA3Code, IsoA2Code, Value) values('{0}', '{1}', '{2}', '{3}', {4})",
                        rate.Country, rate.Currency, rate.IsoA3Code, rate.IsoA2Code, w); //Tudo o que for varchar tem que ter ''.

                    command = new SQLiteCommand(sql, connection);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
            catch(Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
        }

        public List<Rate> GetData()
        {
            List<Rate> rates = new List<Rate>();

            try
            {
                string sql = "select Country, Currency, IsoA3Code, IsoA2Code, Value, Comment from rates";

                command = new SQLiteCommand(sql, connection);

                SQLiteDataReader reader = command.ExecuteReader(); //reader vai buscar recor a record. Lê cada linha ou registo.

                while(reader.Read()) //Ler cada linha
                {
                    rates.Add(new Rate
                        {

                        Country = (string)reader["Country"],
                            Currency = (string)reader["Currency"],
                            IsoA3Code = (string)reader["IsoA3Code"],
                            IsoA2Code = (string)reader["IsoA2Code"],
                            Value = (decimal)reader["Value"]
                    });
                }
                connection.Close();
                return rates;
            }
            catch(Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
                return null; //Tem que retornar sempre algo pois temos uma lista no inicio.
            }
        }

        public void DeleteData()
        {
            try
            {
                string sql = "delete from rates";
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

            }
            catch (Exception e) 
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
        }

    }
}
