using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KaliteGiris.Helper
{
    public class ConnectionStringHelper
    {     

            public static string ConnectionStringConvert(string con, bool dataSourceKey, bool tableNameKey, bool userKey,
                bool passwordKey)
            {
                SqlConnectionStringBuilder decoder = new SqlConnectionStringBuilder(con);

                string t1 = CriptografiaHelper.EncryptQueryString("IK_TEST");
                string t2 = CriptografiaHelper.EncryptQueryString("oracle");
                //string t3 = CriptografiaHelper.EncryptQueryString("sa");
                //string t4 = CriptografiaHelper.EncryptQueryString("54Ee9674!");


                if (dataSourceKey == true)
                    decoder.DataSource = CriptografiaHelper.DecryptQueryString(decoder.DataSource);

                if (tableNameKey == true)
                    decoder.InitialCatalog = CriptografiaHelper.DecryptQueryString(decoder.InitialCatalog);

                if (userKey == true)
                    decoder.UserID = CriptografiaHelper.DecryptQueryString(decoder.UserID);
                if (passwordKey == true)
                    decoder.Password = CriptografiaHelper.DecryptQueryString(decoder.Password);

                return decoder.ConnectionString;
            }

            public static string ConnectionStringConvert(string con)
            {
                //string t1 = CriptografiaHelper.EncryptQueryString("IFSAPP");
                //string t2 = CriptografiaHelper.EncryptQueryString("oracle");


                string s = CriptografiaHelper.DecryptQueryString(con);


                return s;
            }
   }
}

