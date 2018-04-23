using System;
using DevExpress.Xpo;

namespace ContactManagement {
    public class EditObjectEventArgs : EventArgs {
        private object objectToEdit;
        public EditObjectEventArgs(object objectToEdit) {
            this.objectToEdit = objectToEdit;
        }
        public object ObjectToEdit {
            get {
                return objectToEdit;
            }
        }
    }
    public delegate void InsertObjectEventHandler(object sender);
    public delegate void EditObjectEventHandler(object sender, EditObjectEventArgs e);


    public class Address : XPObject {
        [Association("PersonAddresses")]
        public Person Owner;
        public string City = "";
        public string Street = "";
        public bool IsDefault {
            get {
                return Owner != null && Owner.DefaultAddress == this;
            }
        }
        public Address(Address otherAddress)
            : base(otherAddress.Session) {
            this.City = otherAddress.City;
            this.Street = otherAddress.Street;
        }
        public Address(Session session)
            : base(session) {
        }
    }

    public class Attachment : XPObject {
        public string Name = "";
        [Association("PersonAttachments")]
        public Person Owner;
        private XPDelayedProperty document = new XPDelayedProperty();
        [Delayed("document")]
        public Byte[] Document {
            get {
                return (Byte[])document.Value;
            }
            set {
                document.Value = value;
            }
        }
        //		public Attachment() : base() {}
        public Attachment(Session session)
            : base(session) {
        }
    }

    [Persistent("T_Person")]
    public abstract class Person : XPObject {
        public string PhoneNumber = "";
        [Aggregated]
        public Address DefaultAddress = null;
        [Aggregated]
        [Association("PersonAddresses", typeof(Address))]
        public XPCollection Addresses {
            get {
                return GetCollection("Addresses");
            }
        }
        [Aggregated]
        [Association("PersonAttachments", typeof(Attachment))]
        public XPCollection Attachments {
            get {
                return GetCollection("Attachments");
            }
        }
        [Persistent("CreatedOn")]
        private DateTime mCreatedOn = DateTime.Today;
        public DateTime CreatedOn {
            get {
                return mCreatedOn;
            }
        }
        public abstract string DisplayName {
            get;
        }
        public Person(Session session)
            : base(session) {
        }
    }

    [MapInheritance(MapInheritanceType.OwnTable)]
    public class Contact : Person {
        public string FirstName = "";
        public string LastName = "";
        public string Email = "";
        private Company employer = null;
        [Persistent("CompanyID")]
        public Company Employer {
            get {
                return employer;
            }
            set {
                employer = value;
                if (!IsLoading && employer != null && employer.DefaultAddress != null) {
                    Addresses.Remove(DefaultAddress);
                    DefaultAddress = new Address(employer.DefaultAddress);
                    Addresses.Add(DefaultAddress);
                }
            }
        }
        [Persistent]
        public string FullName {
            get {
                return String.Format("{0}, {1}", LastName, FirstName);
            }
        }
        public override string DisplayName {
            get {
                return FullName;
            }
        }
        public Contact(Session session)
            : base(session) {
        }
        public Contact(Session session, Company employer)
            : base(session) {
            this.Employer = employer;
        }
    }

    public class RequiredPropertyValueMissing : Exception {
        public RequiredPropertyValueMissing(XPObject theObject, string propertyName)
            :
            base(String.Format("The {0} property of the {1} object with id {2} must have a value", propertyName, theObject.GetType().Name, theObject.Oid)) {
        }
    }

    [MapInheritance(MapInheritanceType.OwnTable)]
    public class Company : Person {
        public string Name = "";
        public string WebSite = "";
        public override string DisplayName {
            get {
                return Name;
            }
        }
        protected override void OnSaving() {
            if (!IsDeleted) {
                if (Name == "")
                    throw new RequiredPropertyValueMissing(this, "Name");
            }
        }
        public Company(Session session)
            : base(session) {
        }
    }

}