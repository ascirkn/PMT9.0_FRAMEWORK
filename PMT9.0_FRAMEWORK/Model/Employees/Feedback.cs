using PMT9._0_FRAMEWORK.Model.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMT9._0_FRAMEWORK.Model
{
    class Feedback
    {
        internal string EmployeeFeedback { get; set; }
        internal string Employee { get; set; }
        internal string DateFeedback { get; set; }
        internal string AddFeedbackEmployee { get; set; }
        internal Mark MarkType { get; set; }
        internal string Mark { get; set; }
        internal string Comments { get; set; }
        internal string Comment0 { get; set; }
        internal string Comment1 { get; set; }
        internal string Comment2 { get; set; }
        internal string WhatIsOkComment { get; set; }
        internal string WhatToImproveComment { get; set; }
        internal string SupperiorComment { get; set; }
        internal string NameActionPlan { get; set; }
        internal string Receiver { get; set; }
        internal string Questionnaire { get; set; }
        internal string ActionPlan { get; set; }
        public static DateTime today { get; }
        internal string CompetenceType { get; set; }
        internal string Competence { get; set; }
        internal string Goal { get; set; }

    }
}
