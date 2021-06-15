using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPlaneConnector;
using System.Diagnostics;

namespace XPLConnectorTest
{
    class Program
    {
        private static XPlaneConnector.XPlaneConnector conTrueTheta = new XPlaneConnector.XPlaneConnector();
        private static XPlaneConnector.XPlaneConnector conTruePhi = new XPlaneConnector.XPlaneConnector();
        private static XPlaneConnector.XPlaneConnector conAccZ = new XPlaneConnector.XPlaneConnector();
        private static float TrueTheta;
        private static float TruePhi;
        private static float AccZ;

        private static float GetTrueTheta()
        {
            conTrueTheta.Subscribe(XPlaneConnector.DataRefs.FlightmodelPositionTrueTheta, 200, (e, v) =>
            {

                TrueTheta = v;
            });
            return TrueTheta;
        }

        private static float GetTruePhi()
        {
            conTruePhi.Subscribe(XPlaneConnector.DataRefs.FlightmodelPositionTruePhi, 200, (e, v) =>
            {

                TruePhi = v;
            });
            return TruePhi;
        }

        private static float GetAccZ()
        {
            conAccZ.Subscribe(XPlaneConnector.DataRefs.FlightmodelPositionLocalAz, 200, (e, v) =>
            {

                AccZ = v;
            });
            return AccZ;
        }

        static void Main(string[] args)
        {
            // timing
            var watch = new Stopwatch();
            conTrueTheta.Start();
            conTruePhi.Start();
            conAccZ.Start();

            while (true)
            {
                watch.Start();
                Console.Write("true theta: " + GetTrueTheta().ToString() + " true phi: " 
                    + GetTruePhi().ToString() + " acc z: " + GetAccZ().ToString());
                watch.Stop();
                Console.Write($" time: {watch.ElapsedMilliseconds}" + '\n');
                watch.Reset();
            }
        }
    }
}
