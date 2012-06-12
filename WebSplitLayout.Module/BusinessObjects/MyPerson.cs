using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;

namespace WebSplitLayout.Module.BusinessObjects
{

    [DefaultClassOptions]
    public class MyPerson : DevExpress.Persistent.BaseImpl.Person
    {
        public MyPerson(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
    }

}