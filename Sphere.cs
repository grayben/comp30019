using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDX;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.IO;
using Windows.UI.Core;

namespace MiniCube
{
    class Sphere : Shape
    {
        private Vector4 getSphericalCoords(float r, float theta, float phi)
        {
            Vector4 vertex = new Vector4();
            float sinTheta = (float)Math.Sin(theta * Math.PI / 180);
            float cosTheta = (float)Math.Cos(theta * Math.PI / 180);
            float sinPhi = (float)Math.Sin(phi * Math.PI / 180);
            float cosPhi = (float)Math.Cos(phi * Math.PI / 180);

            vertex.X = r * cosTheta * cosPhi;
            vertex.Y = r * sinTheta * cosPhi;
            vertex.Z = -r * sinPhi;
            vertex.W = 1f;
            return vertex;
        }

        public Sphere()
        {
            int dAngle = 30;
            int granularity = 360 / dAngle;
            numVertices = 6 * granularity * granularity;
            vertexDef = new Vector4[(numVertices)*2];
            int i = 0;
            for (int theta = 0; theta < 360; theta += dAngle)
            {
                for (int phi = -90; phi < 90; phi += dAngle)
                {
                    Vector4[] vertexBuffer = new Vector4[4];
                    vertexBuffer[0] = getSphericalCoords(1, (float)theta, (float)phi);
                    vertexBuffer[1] = getSphericalCoords(1, (float)theta, (float)phi + dAngle);
                    vertexBuffer[2] = getSphericalCoords(1, (float)theta + dAngle, (float)phi + dAngle);
                    vertexBuffer[3] = getSphericalCoords(1, (float)theta + dAngle, (float)phi);

                    vertexDef[i++] = vertexBuffer[0]; vertexDef[i++] = new Vector4(0f, 0f, 0f, 1f);
                    vertexDef[i++] = vertexBuffer[1]; vertexDef[i++] = new Vector4(1f, 0f, 1f, 1f);
                    vertexDef[i++] = vertexBuffer[2]; vertexDef[i++] = new Vector4(0f, 1f, 0f, 1f);
                    vertexDef[i++] = vertexBuffer[0]; vertexDef[i++] = new Vector4(0f, 0f, 0f, 1f);
                    vertexDef[i++] = vertexBuffer[2]; vertexDef[i++] = new Vector4(0f, 1f, 0f, 1f);
                    vertexDef[i++] = vertexBuffer[3]; vertexDef[i++] = new Vector4(0f, 1f, 1f, 1f);
                }
            }
        }
    }
}