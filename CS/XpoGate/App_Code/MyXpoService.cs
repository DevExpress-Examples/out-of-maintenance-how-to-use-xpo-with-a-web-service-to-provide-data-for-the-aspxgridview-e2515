using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;


/// <summary>
/// Summary description for MyXpoService
/// </summary>
[WebService(Namespace = WebServiceAttribute.DefaultNamespace)]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class MyXpoService : System.Web.Services.WebService {
    public MyXpoService() { }
    [WebMethod]
    public ModificationResult ModifyData(params ModificationStatement[] dmlStatements) {
        IDataStore provider = (IDataStore)Application["provider"];
        return provider.ModifyData(dmlStatements);
    }
    [WebMethod]
    public SelectedData SelectData(params SelectStatement[] selects) {
        IDataStore provider = (IDataStore)Application["provider"];
        return provider.SelectData(selects);
    }
    [WebMethod]
    public UpdateSchemaResult UpdateSchema(bool dontCreateIfFirstTableNotExist, params DBTable[] tables) {
        // do nothing (do not allow DB schema updates via a public Web service)
        return UpdateSchemaResult.SchemaExists;
    }
    [WebMethod]
    public AutoCreateOption GetAutoCreateOption() {
        return AutoCreateOption.SchemaAlreadyExists;
    }
}
