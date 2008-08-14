/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/8/14
 * Time: 10:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;

namespace Lextm.SharpSnmpLib
{
    /// <summary>
    /// Provides data for a GET response received event.
    /// </summary>
    public sealed class GetResponseReceivedEventArgs : EventArgs, IDisposable
    {
        private GetResponseMessage _response;
        private IPEndPoint _sender;
      
        /// <summary>
        /// Creates a <see cref="GetResponseReceivedEventArgs"/> 
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="response">Response message.</param>
        public GetResponseReceivedEventArgs(IPEndPoint sender, GetResponseMessage response)
        {
            _sender = sender;
            _response = response;
        }
       
        /// <summary>
        /// GET response message.
        /// </summary>
        public GetResponseMessage GetResponse
        {
            get
            {
                return _response;
            }
        }
      
        /// <summary>
        /// Agent.
        /// </summary>
        public IPEndPoint Sender
        {
            get { return _sender; }
        }
        
        /// <summary>
        /// Returns a <see cref="String"/> that represents this <see cref="GetResponseReceivedEventArgs"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "GET response received event args: GET response message: " + _response + "; sender: " + _sender;
        }
        
        private bool _disposed;
        
        /// <summary>
        /// Finalizer of <see cref="GetResponseReceivedEventArgs"/>.
        /// </summary>
        ~GetResponseReceivedEventArgs()
        {
            Dispose(false);
        }
        
        /// <summary>
        /// Releases all resources used by the <see cref="GetResponseReceivedEventArgs"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// Disposes of the resources (other than memory) used by the <see cref="GetResponseReceivedEventArgs"/>.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            
            if (disposing)
            {
                _response.Dispose();
            }
            
            _disposed = true;
        }
    }
}