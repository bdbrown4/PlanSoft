﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;


namespace MvcAdminTemplate.Controllers
{
    public class AttributesVariablesController : Controller
    {
        //
        // GET: /AttributesVariables/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadAttributes()
        {
            return Json(new
            {
                aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string AttribCode)
        {
            foreach (AttributesVariablesViewModel i in AttributesVariablesViewModel.AttributesVariablesList)
            {
                if (i.AttributeCode == AttribCode)
                {
                    AttributesVariablesViewModel.AttributesVariablesList.Remove(i);
                    return Json(new
                    {
                        aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string varCode, string NewAttribCode, string NewAttribName, string NewVarName, string NewVarCode)
        {
            foreach (AttributesVariablesViewModel i in AttributesVariablesViewModel.AttributesVariablesList)
            {
                if (i.AttributeCode == varCode)
                {
                    i.AttributeCode = NewAttribCode;
                    i.AttributeName = NewAttribName;
                    i.VariableCode = NewVarCode;
                    i.VariableName = NewVarName;
                    i.DateSet = DateTime.Today;

                    return Json(new
                    {
                        aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string AttribCode, string AttribName, string varCode, string varName, string Creator)
        {
            AttributesVariablesViewModel.AttributesVariablesList.Add(new AttributesVariablesViewModel { AttributeCode = AttribCode, AttributeName = AttribName, VariableCode = varCode, VariableName = varName, DateSet = DateTime.Today, CreatedBy = Creator });

            return Json(new
            {
                aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
