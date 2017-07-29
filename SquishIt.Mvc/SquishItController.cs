using System.Web.Mvc;
using SquishIt.Framework;
using System;

namespace SquishIt.Mvc
{
	public class SquishItController: Controller
	{
		public ActionResult Js(string id)
		{
            // Set max-age to a year from now
            Response.Cache.SetMaxAge(TimeSpan.FromDays(365));
            return Content(Bundle.JavaScript().RenderCached(id), Configuration.Instance.JavascriptMimeType);
		}

		public ActionResult Css(string id)
		{
            // Set max-age to a year from now
            Response.Cache.SetMaxAge(TimeSpan.FromDays(365));
            return Content(Bundle.Css().RenderCached(id), Configuration.Instance.CssMimeType);
		}
	}
}