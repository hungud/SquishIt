﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using SquishIt.Framework.Base;
using SquishIt.Hogan.Hogan;
using SquishIt.Framework;

namespace SquishIt.Hogan
{
    /// <summary>
    /// Preprocessor for Hogan templates that uses Jurassic to execute JavaScript in-process.
    /// </summary>
    public class HoganPreprocessor : Preprocessor
    {
        public override string[] Extensions
        {
            get { return new[] { ".hogan" }; }
        }

        public override string[] IgnoreExtensions
        {
            get { return new [] { ".html" }; }
        }

        public override IProcessResult Process(string filePath, string content)
        {
            var compiler = new HoganCompiler();
            string renderFunc = compiler.Compile(content);
            string templateName = Path.GetFileName(filePath).Split('.').First();
		    string templateHtml = string.Join("\\r\"+\"\\n",
		                           content.Replace("\"", "\\\"").Split(new[] {Environment.NewLine}, StringSplitOptions.None));
            var sb = new StringBuilder();
            sb.AppendLine("var JST = JST || {};");
            sb.AppendLine("JST['" + templateName + "'] = new Hogan.Template(" + renderFunc + ",\"" + templateHtml + "\",Hogan,{});");
            return new ProcessResult(sb.ToString());
        }
    }
}