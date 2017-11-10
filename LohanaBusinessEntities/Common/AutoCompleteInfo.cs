using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Common
{
    public class IdTextInfo 
	{
        public int Id { get; set; }

        public string Text { get; set; }
    }

	public class AutocompleteInfo
	{
		public int AutocompleteId
		{
			get;
			set;
		}

		public string PageName
		{
			get;
			set;
		}

		public string ControlName
		{
			get;
			set;
		}

		public string TableName
		{
			get;
			set;
		}

		public string TextFieldName
		{
			get;
			set;
		}

		public string IdFieldName
		{
			get;
			set;
		}

		public string DependentControlName
		{
			get;
			set;
		}

		public string DependentFieldName
		{
			get;
			set;
		}

		public string ExtraFields
		{
			get;
			set;
		}

		public bool IsMultiselect
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}

	}

}
