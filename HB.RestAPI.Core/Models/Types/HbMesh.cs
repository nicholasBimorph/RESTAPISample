using System;
using System.Collections.Generic;
using System.Text;
using HB.RestAPI.Core.Interfaces;
using HB.RestAPI.Core.Models;
using Newtonsoft.Json;

namespace HB.RestAPI.Core.Types
{
    public class HbMesh : IHbObject
    {
        public double [][] Vertices { get; set; }

        public int [][] FaceIndexes { get; set; }

        public int[][] VertexColors { get; set; }

        public IList<Property> Properties { get; set; }


        [JsonConstructor]
        public HbMesh(
            double[][] vertices, 
            int [][] faceIndexes, 
            int[][] vertexColors = null,
            IList<Property> properties = null)
        {
            this.Vertices = vertices;

            this.FaceIndexes = faceIndexes;

            this.VertexColors = vertexColors;

            this.Properties = properties;

        }

    }
}
