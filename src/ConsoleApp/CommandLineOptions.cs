using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace WordCounter.ConsoleApp
{
    /// <summary>
    /// A class to receive parsed command line parameters
    /// </summary>
    public class CommandLineOptions
    {
        [Option('s', "source", HelpText = "Original file name.", Required = true)]
        public string SourceFileName { get; set; }

        [Option('r', "result", HelpText = "Result file name.", Required = true)]
        public string ResultFileName { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
