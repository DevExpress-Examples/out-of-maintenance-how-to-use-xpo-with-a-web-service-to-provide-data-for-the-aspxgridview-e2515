using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;


[WebServiceBinding(Namespace = WebServiceAttribute.DefaultNamespace)]
class MyWebDataStore : DevExpress.Xpo.WebServiceDataStore {
    public MyWebDataStore(string url)
        : base(url, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists) {
    }
}

