using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinAPI;

namespace ExportImport.ConversionClientLib {
	public static class SessionFactory {

		public const int PORT = 80;//默认80

		public static Session CreateSession(string hostname) {
			return CreateSession(hostname, PORT);
		}
		
		public static Session CreateSession(string hostname, int port) {
			return new Session(Session.STANDARD_TIMEOUT, hostname, port);
		}

		public static Session CreateSession(Session session, int timeout) {
			return new Session(session, timeout);
		}
	}
}
