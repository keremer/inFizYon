﻿using System;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;

namespace BasicExamples
{
    public class StepToXmlExample
    {
        public static void Convert()
        {
            //open STEP21 file
            using (var stepModel = IfcStore.Open("SampleHouse.ifc"))
            {
                //save as XML
                stepModel.SaveAs("SampleHouse.ifcxml");

                //open XML file
                using (var xmlModel = IfcStore.Open("SampleHouse.ifcxml"))
                {
                    //just have a look that it contains the same number of entities and walls.
                    var stepCount = stepModel.Instances.Count;
                    var xmlCount = xmlModel.Instances.Count;

                    var stepWallsCount = stepModel.Instances.CountOf<IIfcWall>();
                    var xmlWallsCount = xmlModel.Instances.CountOf<IIfcWall>();

                    Console.WriteLine($"STEP21 file has {stepCount} entities. XML file has {xmlCount} entities.");
                    Console.WriteLine($"STEP21 file has {stepWallsCount} walls. XML file has {xmlWallsCount} walls.");
                }
            }

        }
    }
}
