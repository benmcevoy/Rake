using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rake.Tests
{
    [TestClass]
    public class RakeTests
    {
        [TestMethod]
        public void Rake_Sort_Of_Works()
        {
            const string text = @"Compatibility of systems of linear constraints over the set of natural numbers. 
Criteria of compatibility of a system of linear Diophantine equations, strict inequations, and nonstrict inequations are considered. 
Upper bounds for components of a minimal set of solutions and algorithms of construction of minimal generating sets of solutions for all types of systems are given. 
These criteria and the corresponding algorithms for constructing a minimal supporting set of solutions can be used in solving all the considered types of systems and systems of mixed types.";

            var rake = new Rake();

            var result = rake.Run(text);

            Assert.IsNotNull(result);

            // from https://www.airpair.com/nlp/keyword-extraction-tutorial

            // expected was
            /*
             * Keyword:  minimal generating sets , score:  8.66666666667
            Keyword:  linear diophantine equations , score:  8.5
            Keyword:  minimal supporting set , score:  7.66666666667
            Keyword:  minimal set , score:  4.66666666667
            Keyword:  linear constraints , score:  4.5
            Keyword:  upper bounds , score:  4.0
            Keyword:  natural numbers , score:  4.0
            Keyword:  nonstrict inequations , score:  4.0
            */

            Assert.AreEqual("minimal generating sets", result.Skip(0).First().Key);
            Assert.AreEqual("linear diophantine equations", result.Skip(1).First().Key);
            Assert.AreEqual("minimal supporting set", result.Skip(2).First().Key);
            Assert.AreEqual("minimal set", result.Skip(3).First().Key);
            Assert.AreEqual("linear constraints", result.Skip(4).First().Key);
            
            // we then hit a few that are scored the same and the order is slightly different
            //Assert.AreEqual("upper bounds", result.Skip(5).First().Key);
            //Assert.AreEqual("natural numbers", result.Skip(6).First().Key);
            //Assert.AreEqual("nonstrict inequations", result.Skip(7).First().Key);

            // but the score is OK so we are green
            Assert.AreEqual(4.0, result["upper bounds"]);
        }

        [TestMethod]
                    public void Just_Looking_At_Some_Results()
                    {
                        var text =
                            @"Iraq has launched the long-awaited offensive to expel Islamic State from its second largest city Mosul and Australian personnel and aircraft will certainly be involved in support operations.

            But Defence won't say just what or how.

            'Defence will not discuss specific details for operational security reasons,' a defence spokesman said.

            Defence Minister Marise Payne declined to comment on operational details, saying it would take time and she was awaiting updates.

            She also declined to elaborate on predictions of civilian casualties.

            'I don't think my conjecture on rates of casualties or otherwise would be helpful at this point,' she said.

            Australia has a substantial force in the Middle East, extensively involved in the fight against Islamic State.

            The six F/A-18 Hornets of the RAAF Air Task Group will operate as part of the coalition air contingent, hitting IS targets in the city.

            The RAAF KC-30A refueling aircraft will support the air campaign, as will the E-7A Wedgetail airborne warning and control aircraft.

            Closest to Australian boots on the ground could be the 80-stong special operations task group whose members have advised and mentored Iraq's elite Counter-Terrorism Service.

            This unit, referred to as the Golden Division, played a key role in the fight to retake Ramadi.

            Iraqi infantry trained by the 300 Australians and 100 New Zealanders of Task Group Taji will be in the thick of the fighting.

            Another 30 Australian personnel are embedded in coalition headquarters in Baghdad.

            US Lieutenant General Stephen Townsend, commander of the coalition taskforce, said the operation to regain control of Mosul would likely continue for weeks, possibly longer.

            He said Iraq was supported by a wide range of coalition capabilities, including air support, artillery, intelligence, advisors and forward air controllers.

            'But to be clear, the thousands of ground combat forces who will liberate Mosul are all Iraqis,' he said in a statement.

            'This may prove to be a long and tough battle, but the Iraqis have prepared for it and we will stand by them.'";

                        var rake = new Rake(minCharLength: 4, maxWordsLength: 12);

                        var result = rake.Run(text);

                        Assert.IsNotNull(result);

                        var result2 = rake.Run(string.Join("|", result.Select(pair => pair.Key)));

                        Assert.IsNotNull(result2);
                    }
                }
            }
