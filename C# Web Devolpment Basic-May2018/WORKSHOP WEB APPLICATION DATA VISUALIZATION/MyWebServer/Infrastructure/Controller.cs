namespace MyWebServer.Infrastructure
{
    using Server.Enums;
    using Server.HTTP.Responce;
    using Server.HTTP.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public abstract class Controller 
    {
      
       // public const string DefaultPath = @"../../../../MyWebServer\{0}\Resources\{1}.html";
        public const string DefaultPath = @"..\..\..\{0}\Resources\{1}.html";

        public const string ContentPlaceholder = "{{{content}}}";

        protected Controller()
        {
            this.ViewData = new Dictionary<string, string>
            {
                ["anonymousDisplay"] = "none",
                ["authDisplay"] = "flex",
                ["showError"] = "none"
            };
        }

        protected IDictionary<string, string> ViewData { get; private set; }

        protected abstract string ApplicationDirectory { get; }

        protected IHttpResponse RedirectResponce(string route)
        {
            return new RedirectResponse(route);
        }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

            if (this.ViewData.Any())
            {
                foreach (var value in this.ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

               return new ViewResponse(HttpStatusCode.OK, new FileView(result));
        }
        
        private string ProcessFileHtml(string fileName)
        {
            var layoutHtml = File.ReadAllText(string.Format(DefaultPath, this.ApplicationDirectory, "layout"));

            var fileHtml = File
                .ReadAllText(string.Format(DefaultPath, this.ApplicationDirectory, fileName));

            var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);

            return result;
        }

        protected void ShowError(string errorMessage)
        {
            this.ViewData["showError"] = "block";
            this.ViewData["error"] = errorMessage;
        }

        protected bool ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(model, context, results, true) == false)
            {
                foreach (var result in results)
                {
                    if (result != ValidationResult.Success)
                    {
                         this.ShowError(result.ErrorMessage);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
