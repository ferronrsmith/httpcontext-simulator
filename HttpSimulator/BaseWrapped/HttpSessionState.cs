using System;
using System.Web;
using System.Web.SessionState;

namespace Http.TestLibrary.BaseWrapped
{
    internal class HttpSessionState : HttpSessionStateBase
    {
        private HttpSimulator.FakeHttpSessionState session;

        public HttpSessionState(HttpSimulator.FakeHttpSessionState session)
        {
            this.session = session;
        }

        ///<summary>
        ///Ends the current session.
        ///</summary>
        ///
        public override void Abandon()
        {
            session.Abandon();
        }

        ///<summary>
        ///Adds a new item to the session-state collection.
        ///</summary>
        ///
        ///<param name="name">The name of the item to add to the session-state collection. </param>
        ///<param name="value">The value of the item to add to the session-state collection. </param>
        public override void Add(string name, object value)
        {
            session.Add(name,value);
        }

        ///<summary>
        ///Deletes an item from the session-state item collection.
        ///</summary>
        ///
        ///<param name="name">The name of the item to delete from the session-state item collection. </param>
        public override void Remove(string name)
        {
            session.Remove(name);
        }

        ///<summary>
        ///Deletes an item at a specified index from the session-state item collection.
        ///</summary>
        ///
        ///<param name="index">The index of the item to remove from the session-state collection. </param>
        public override void RemoveAt(int index)
        {
            session.RemoveAt(index);
        }

        ///<summary>
        ///Clears all values from the session-state item collection.
        ///</summary>
        ///
        public override void Clear()
        {
            session.Clear();
        }

        ///<summary>
        ///Clears all values from the session-state item collection.
        ///</summary>
        ///
        public override void RemoveAll()
        {
            session.RemoveAll();
        }

        ///<summary>
        ///Copies the collection of session-state item values to a one-dimensional array, starting at the specified index in the array.
        ///</summary>
        ///
        ///<param name="array">The <see cref="T:System.Array"></see> that receives the session values. </param>
        ///<param name="index">The index in array where copying starts. </param>
        public override void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///Gets the unique session identifier for the session.
        ///</summary>
        ///
        ///<returns>
        ///The session ID.
        ///</returns>
        ///
        public override string SessionID
        {
            get { return session.SessionID; }
        }

        ///<summary>
        ///Gets and sets the time-out period (in minutes) allowed between requests before the session-state provider terminates the session.
        ///</summary>
        ///
        ///<returns>
        ///The time-out period, in minutes.
        ///</returns>
        ///
        public override int Timeout
        {
            get { return session.Timeout; }
            set { session.Timeout = value; }
        }

        ///<summary>
        ///Gets a value indicating whether the session was created with the current request.
        ///</summary>
        ///
        ///<returns>
        ///true if the session was created with the current request; otherwise, false.
        ///</returns>
        ///
        public override bool IsNewSession
        {
            get { return session.IsNewSession; }
        }

        ///<summary>
        ///Gets the current session-state mode.
        ///</summary>
        ///
        ///<returns>
        ///One of the <see cref="T:System.Web.SessionState.SessionStateMode"></see> values.
        ///</returns>
        ///
        public override SessionStateMode Mode
        {
            get { return session.Mode; }
        }

        ///<summary>
        ///Gets a value indicating whether the session ID is embedded in the URL or stored in an HTTP cookie.
        ///</summary>
        ///
        ///<returns>
        ///true if the session is embedded in the URL; otherwise, false.
        ///</returns>
        ///
        public override bool IsCookieless
        {
            get { return session.IsCookieless; }
        }

        ///<summary>
        ///Gets a value that indicates whether the application is configured for cookieless sessions.
        ///</summary>
        ///
        ///<returns>
        ///One of the <see cref="T:System.Web.HttpCookieMode"></see> values that indicate whether the application is configured for cookieless sessions. The default is <see cref="F:System.Web.HttpCookieMode.UseCookies"></see>.
        ///</returns>
        ///
        public override HttpCookieMode CookieMode
        {
            get { return session.CookieMode; }
        }

        ///<summary>
        ///Gets or sets the locale identifier (LCID) of the current session.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Globalization.CultureInfo"></see> instance that specifies the culture of the current session.
        ///</returns>
        ///
        public override int LCID
        {
            get { return session.LCID; }
            set { session.LCID = value; }
        }

        ///<summary>
        ///Gets or sets the code-page identifier for the current session.
        ///</summary>
        ///
        ///<returns>
        ///The code-page identifier for the current session.
        ///</returns>
        ///
        public override int CodePage
        {
            get { return session.CodePage; }
            set { session.CodePage = value; }
        }

        ///<summary>
        ///Gets a collection of objects declared by &lt;object Runat="Server" Scope="Session"/&gt; tags within the ASP.NET application file Global.asax.
        ///</summary>
        ///
        ///<returns>
        ///An <see cref="T:System.Web.HttpStaticObjectsCollection"></see> containing objects declared in the Global.asax file.
        ///</returns>
        ///
        public override HttpStaticObjectsCollectionBase StaticObjects
        {
            get
            {
                throw new NotImplementedException();
                //return session.StaticObjects; 
            }
        }

        ///<summary>
        ///Gets or sets a session-state item value by name.
        ///</summary>
        ///
        ///<returns>
        ///The session-state item value specified in the name parameter.
        ///</returns>
        ///
        ///<param name="name">The key name of the session-state item value. </param>
        public override object this[string name]
        {
            get { return session[name]; }
            set { session[name] = value; }
        }

        ///<summary>
        ///Gets or sets a session-state item value by numerical index.
        ///</summary>
        ///
        ///<returns>
        ///The session-state item value specified in the index parameter.
        ///</returns>
        ///
        ///<param name="index">The numerical index of the session-state item value. </param>
        public override object this[int index]
        {
            get { return session[index]; }
            set { session[index]=value; }
        }

        ///<summary>
        ///Gets an object that can be used to synchronize access to the collection of session-state values.
        ///</summary>
        ///
        ///<returns>
        ///An object that can be used to synchronize access to the collection.
        ///</returns>
        ///
        public override object SyncRoot
        {
            get { return session.SyncRoot; }
        }

        ///<summary>
        ///Gets a value indicating whether access to the collection of session-state values is synchronized (thread safe).
        ///</summary>
        ///<returns>
        ///true if access to the collection is synchronized (thread safe); otherwise, false.
        ///</returns>
        ///
        public override bool IsSynchronized
        {
            get { return session.IsSynchronized; }
        }
    }
}