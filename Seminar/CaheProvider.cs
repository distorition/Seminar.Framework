using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Seminar
{
    public class CaheProvider//клас для шифрования и дешифрования данных
    {
        public void CaheConnection(List<ConnectionString> connections)//передаем коллекцию строк конекта 
        {
            XmlSerializer xmlSerializer= new XmlSerializer(typeof(CaheProvider));
        }

        public List<ConnectionString> GetConnectionsFromCahe()
        {
            return null;
        }
    }
}
