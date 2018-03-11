using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class Topic { 

		/// <summary>
		/// The name of the topic. It must have the format
		///`"projects/{project}/topics/{topic}"`. `{topic}` must start with a letter,
		///and contain only letters (`[A-Za-z]`), numbers (`[0-9]`), dashes (`-`),
		///underscores (`_`), periods (`.`), tildes (`~`), plus (`+`) or percent
		///signs (`%`). It must be between 3 and 255 characters in length, and it
		///must not start with `"goog"`.
		/// </summary>
		public string name { get; set; }

	}
}