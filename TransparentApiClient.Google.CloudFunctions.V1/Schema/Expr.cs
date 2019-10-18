using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class Expr { 

		/// <summary>
		/// An optional title for the expression, i.e. a short string describing
		///its purpose. This can be used e.g. in UIs which allow to enter the
		///expression.
		/// </summary>
		public string title { get; set; }

		/// <summary>
		/// An optional string indicating the location of the expression for error
		///reporting, e.g. a file name and a position in the file.
		/// </summary>
		public string location { get; set; }

		/// <summary>
		/// An optional description of the expression. This is a longer text which
		///describes the expression, e.g. when hovered over it in a UI.
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Textual representation of an expression in
		///Common Expression Language syntax.
		///
		///The application context of the containing message determines which
		///well-known feature set of CEL is supported.
		/// </summary>
		public string expression { get; set; }

	}
}