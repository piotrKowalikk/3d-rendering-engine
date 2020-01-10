using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace gk4p1
{
    static class CameraUIHandlers
    {
        static public void ConstantCameraHandler(GlobalObject global, Camera camera, ref ViewMatrix viewMatrix, string XCameraTextBoxText, string YCameraTextBoxText, string ZCameraTextBoxText)
        {
            Vector3 cameraNewPosition = camera.Position;
            if (float.TryParse(XCameraTextBoxText, out float rsl))
                cameraNewPosition.X = rsl;
            if (float.TryParse(YCameraTextBoxText, out float rsl2))
                cameraNewPosition.Y = rsl2;
            if (float.TryParse(ZCameraTextBoxText, out float rsl3))
                cameraNewPosition.Z = rsl3;

            camera.UpdateCamera(cameraNewPosition);
            viewMatrix.Camera = camera;
            global.ViewMatrix = viewMatrix;
        }



        internal static void UpdateCameraTarget(GlobalObject global, Mesh mesh ,Camera camera, ref ViewMatrix viewMatrix1)
        {
            camera.Target = mesh.Position;
            viewMatrix1.Camera = camera;
            global.ViewMatrix = viewMatrix1;
        }

        internal static void ClearTarget(GlobalObject global, Camera camera, ref ViewMatrix viewMatrix1)
        {
            camera.Target = new Vector3();
            viewMatrix1.Camera = camera;
            global.ViewMatrix = viewMatrix1;
        }
    }
}
