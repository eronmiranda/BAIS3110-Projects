using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3110InputValidation.Pages
    {
    public class IndexModel : PageModel
        {
        public string NameResponse;
        public string MessageResponse;
        public string FilenameResponse;

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string MessageText { get; set; }

        [BindProperty]
        public string Filename { get; set; }

        public void OnPost()
        {
            // Name Textbox
            if (UserName != null)
            {
            string Name = UserName; // Grab the UserName from the Form

            Regex NameRegularExpression = new Regex(@"^[a-zA-Z ]{3,}$");
            if (NameRegularExpression.Match(Name).Success)
                NameResponse = Name;
            else
                NameResponse = "Name is too short. Special characters are not allowed";
            }
            // MessageText Textarea
            if (MessageText != null)
            {
                StringBuilder stringBuilder = new StringBuilder(
                        HttpUtility.HtmlEncode(MessageText));

                stringBuilder.Replace("&lt;b&gt;", "<b>");
                stringBuilder.Replace("&lt;/b&gt;", "</b>");

                stringBuilder.Replace("&lt;i&gt;", "<i>");
                stringBuilder.Replace("&lt;/i&gt;", "</i>");

                stringBuilder.Replace("&lt;u&gt;", "<u>");
                stringBuilder.Replace("&lt;/u&gt;", "</u>");

                MessageResponse = stringBuilder.ToString();
            }

            if(Filename != null)
            {
                Regex r = new Regex(@"txt|rtf|gif|jpg|bmp$", RegexOptions.IgnoreCase);
                if(r.Match(Filename).Success)
                {
                    FilenameResponse = Filename;
                }
                else
                {
                    FilenameResponse = "Filename extension is invalid";
                }
            }
        }
        }
    }
