using MarsRover.Models;
using MarsRover.Utility;
using MarsRoverTest.Tests;

namespace MarsRoverTest.Tests
{
    [TestClass]
    public class SanitizeFileTests
    {
        [TestMethod]
        public void FileShouldHaveNoEmptyLines()
        {
            SanitizeFile sanitizeFile = new SanitizeFile { fileName = "../../../testData.txt" };
            string[] fileContents = sanitizeFile.SanitizeFileContents(sanitizeFile.fileName);
            var noEmptyLines = true;
            foreach (var line in fileContents)
            {
                if(String.IsNullOrEmpty(line))
                {
                    noEmptyLines = false;
                }
            }
            Assert.AreEqual(true, noEmptyLines);
        }
    }
}



//class MissionTest(unittest.TestCase):
//@classmethod
//def setUp(cls):
//    cls.mission_str = '''
//      5 5
//      1 2 N
//      LMLMLMLMM
//    '''

//  @classmethod
//  def tearDown(cls):
//    cls.mission_str = None


//  def test_mission_initialization(self):
//    mission = Mission.from_str(MissionTest.mission_str)


//    self.assertEqual(mission.terrain.latitude, 5)
//    self.assertEqual(mission.terrain.longitude, 5)
//    self.assertEqual(mission.rovers.__len__(), 1)


//  def test_complete_rover_missions_single(self):
//    mission_str = '''
//      5 5
//      1 2 N
//      LMLMLMLMM
//    '''
//    mission = Mission.from_str(mission_str)
  
//    r = mission.rovers[0]
//    self.assertEqual(r.current_position(), "x: 1, y: 2, heading: N")


//    mission.complete_rover_missions()

//    # 5 5
//# 1 2 N
//# LM LM LM LMM
//# LM -> 0,2 W
//# LM -> 0,1 S
//# LM -> 1,1 E
//# LMM -> 1,3 N
//    r = mission.rovers[0]
//    self.assertEqual(r.current_position(), "x: 1, y: 3, heading: N")

//  def test_complete_rover_missions_multi(self):
//    mission_str = '''
//      5 5
//      1 2 N
//      LMLMLMLMM
//      3 3 E
//      MMRMMRMRRM
//    '''
//    mission = Mission.from_str(mission_str)

//    r = mission.rovers[0]
//    self.assertEqual(r.current_position(), "x: 1, y: 2, heading: N")
//    r = mission.rovers[1]
//    self.assertEqual(r.current_position(), "x: 3, y: 3, heading: E")


//    mission.complete_rover_missions()

//    # 5 5
//# 3 3 E
//# MM RMM RM RRM
//# MM  -> 5,3 E
//# RMM -> 5,1 S
//# RM  -> 4,1 W
//# RRM -> 5,1 E
//    r = mission.rovers[0]
//    self.assertEqual(r.current_position(), "x: 1, y: 3, heading: N")
//    r = mission.rovers[1]
//    self.assertEqual(r.current_position(), "x: 5, y: 1, heading: E")

//  @unittest.skip("skipping testing visual")
//  def test_display_rover_missions(self):
//    mission = Mission.from_str(MissionTest.mission_str)

//    mission.display_rover_missions()