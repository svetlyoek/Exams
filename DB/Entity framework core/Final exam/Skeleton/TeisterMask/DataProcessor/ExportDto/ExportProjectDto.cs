using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlAttribute(AttributeName = "TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement(ElementName = "ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement(ElementName = "HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray(ElementName = "Tasks")]
        public ExportTaskDto[] Tasks { get; set; }
    }
}
