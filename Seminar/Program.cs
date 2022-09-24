using Seminar;

var connectionString = new ConnectionString
{
    DataBaseName = "DataBase1",
    Host = "LocalHos",
    Password = "123",
    UserName = "User1"
};
var connectionString2 = new ConnectionString
{
    DataBaseName = "DataBase2",
    Host = "LocalHost",
    Password = "12345",
    UserName = "User2"
};
List<ConnectionString> connections = new List<ConnectionString>();
connections.Add(connectionString);
connections.Add(connectionString2);

CaheProvider caheProvider = new CaheProvider();
caheProvider.CaheConnection(connections);
var connect=caheProvider.GetConnectionsFromCahe();
foreach(var item in connect)
{
    Console.WriteLine(item);
}