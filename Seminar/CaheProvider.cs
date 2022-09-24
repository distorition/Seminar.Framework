using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace Seminar
{
    public class CaheProvider//клас для шифрования и дешифрования данных
    {
        static byte[] SecretKey = { 5, 4, 2, 3, 43, };//наш секретный ключ который будет нам для шифрования наших xxml файлов
        public void CaheConnection(List<ConnectionString> connections)//передаем коллекцию строк конекта 
        {
            try
            {
            XmlSerializer xmlSerializer= new XmlSerializer(typeof(CaheProvider));
            using  MemoryStream memoryStream = new MemoryStream();//при помощи этого класса     мы сможем хранить наши настройки в рамках нашего приложения 
            using  XmlTextWriter  xmlTextWriter = new XmlTextWriter(memoryStream,Encoding.UTF8);//первй параметр значит то что  сохранять xml документ мы будем в нашем приложении 
            xmlSerializer.Serialize(xmlTextWriter, connections);//таким образом мы наши строки подключения связываем с xml которые будут храниться в памяти нашего приложения

            byte[] protectedData = Protect( memoryStream.ToArray());

            File.WriteAllBytes("protecteData",protectedData);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Serialized Filed");
            }
        }


        /// <summary>
        /// используем метод для зашифровки наших xml файлов 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] Protect(byte[] data)
        {
            try
            {
            //CurrentUser- значит что расшифровать эти данные сможет только текущий пользователь 
            //LocalMachine-данные может рашифровать любой на ЭТОМ компьютере на котором было сделано шифрование( на других компах не сможет )
          return ProtectedData.Protect(data,SecretKey,DataProtectionScope.CurrentUser);//передаем сюда что мы собираемся шифровать и секретный ключ чтобы данные смогли дешифрвоать только при помощи нашего ключа
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Protecdet Error");
                return null; 
            }
        }

        public List<ConnectionString> GetConnectionsFromCahe()
        {
            try
            {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CaheProvider));//создаем сериализатор
            byte[] protecdedData= File.ReadAllBytes("protecteData");//берем наши зашифрованные  данные
            byte[] data=  Unporotect(protecdedData);//дешифруем
            var result= xmlSerializer.Deserialize(new MemoryStream(data));//десериализатор принимает данные только в потоке поэтому мы создаем Поток(MemoryStream ) и передаем туда наш массив байт 
            return (List<ConnectionString>)result;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Deserialized Data Error");
                throw ex;
            }
        }

        /// <summary>
        /// метод для дешифровки данных
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] Unporotect(byte[] data)
        {
            try
            {
                return  ProtectedData.Unprotect(data,SecretKey,DataProtectionScope.CurrentUser);//так же нужжно указать в рамках какого режим мы зашифровывали данные CurrentUser или LocalMachi
            }
            catch(CryptographicException ex)
            {
                Console.WriteLine("Unprotect Error");
                throw ex;
            }
        }
    }
}
