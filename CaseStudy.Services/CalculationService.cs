using CaseStudy.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CaseStudy.Services
{
    public static class CalculationService
    {
        //TODO: should come from db and make cache 
        private static List<string> BadKeyword = new List<string>() {
            "mesai"
        };

        internal static int CalculateJobQualityScore(PostCompanyJobAdvertisementServiceRequest request)
        {
            var score = 0;
            if (!string.IsNullOrEmpty(request.Position))
            {
                score++;
            }
            if (request.Salary > 0)
            {
                score++;
            }
            if (!string.IsNullOrEmpty(request.Benefits))
            {
                score++;
            }
            if (Filter(request.Description, BadKeyword.ToArray()) == 0)
            {
                score += 2;
            } 
            return score;
        }

        private static int Filter(string input, string[] badWords)
        {
            var re = new Regex(
                @"\b("
                + string.Join("|", badWords.Select(word =>
                    string.Join(@"\s*", word.ToCharArray())))
                + @")\b", RegexOptions.IgnoreCase);

            return re.Matches(input).Count;
        }
    }
}
