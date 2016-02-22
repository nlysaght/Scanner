using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    public interface IPhoneAnalyzer
    {
        IList<PhoneCapture> Capture(string input);
    }

    public class PhoneCapture
    {
        public string Nemonic { get; set; }
        public string Number { get; set; }
        public override string ToString()
        {
            return $"{Nemonic} {Number}".Trim();
        }
    }

    public class PhoneAnalyzer : IPhoneAnalyzer
    {
        private char[] ignore = new char[] {'(', ')', '-', '.', ' ' };
        private List<string> allowedNemonics = new List<string>() {"phone", "fax", "tel", "telephone"  };
        public IList<PhoneCapture> Capture(string input)
        {
            var captures = new List<string>();
            var strongCaptures = new List<PhoneCapture>();
            input += "|Break";
            using (var reader = new StringReader(input))
            {
                var startCapture = false;
                var endCapture = false;
                var resetCapture = false;
                var currentCapture = new List<char>();
                var workingNemonic = string.Empty;
                var currentNemonic = string.Empty;
                while (reader.Peek() != -1)
                {
                    if(endCapture) 
                    {
                        var numericsCount = currentCapture.Count(x => char.IsNumber(x));
                        // Need 8 or more numerics to count as a phone number
                        if (numericsCount >=8 && numericsCount <= 15)
                        {
                            captures.Add(currentNemonic + " " + new string(currentCapture.ToArray()));
                            var capture = new PhoneCapture() { Nemonic = currentNemonic, Number = new string(currentCapture.ToArray()) };
                            strongCaptures.Add(capture);
                        }
                        resetCapture = true;
                    }
                    if(resetCapture)
                    {
                        resetCapture = false;
                        startCapture = false;
                        endCapture = false;
                        currentCapture = new List<char>();
                        currentNemonic = string.Empty;
                        workingNemonic = string.Empty;
                    }
                    var c = (char)reader.Read();
                    if(!startCapture  && ( c == '+' || char.IsNumber(c)))
                    {
                        startCapture = true;
                        currentCapture.Add(c);
                    }
                    else
                    {
                        // Get out of here if we're in a capture but the next character is not allowed in a phone number
                        if (startCapture && (!char.IsNumber(c) && !ignore.Contains(c)))
                        {
                            endCapture = true;
                            resetCapture = true;
                            continue;
                        }
                        else
                        {
                            if(startCapture)
                                currentCapture.Add(c);
                            else
                            {
                                // Start Capture nemonic. (phone, fax etc).
                                workingNemonic += c.ToString().ToLower();
                                if(allowedNemonics.Contains(workingNemonic))
                                {
                                    currentNemonic = workingNemonic;
                                }
                                if(!(from n in allowedNemonics where n.StartsWith(workingNemonic) select n).Any() )
                                {
                                    workingNemonic = string.Empty;
                                }
                            }
                        }
                    }
                }
                if(startCapture)
                {
                    if (currentCapture.Count(x => char.IsNumber(x)) > 6)
                        captures.Add(new string(currentCapture.ToArray()));

                }
            }
            return strongCaptures;
        }
    }
}
