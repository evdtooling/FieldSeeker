using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System.Xml;

namespace Field_Seeker
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void searchField_Click(object sender, EventArgs e)
        {
            ExecuteMethod(SearchField);
        }
        private void SearchField()
        {
            if (fieldName.TextLength > 0)
            {
                string fieldname = fieldName.Text.ToLower();

                RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
                metaDataRequest.EntityFilters = EntityFilters.Attributes;

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Searching field in all entities...",
                    Work = (worker, args) =>
                    {

                        args.Result = (RetrieveAllEntitiesResponse)Service.Execute(metaDataRequest);
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        var result = args.Result as RetrieveAllEntitiesResponse;
                        if (result != null)
                        {
                            //Create an entitycounter and retrieve the EntityMetadata
                            int counter = 0;
                            var entities = result.EntityMetadata;
                            //Clear the TreeView before refill
                            resultsTree.Nodes.Clear();

                            foreach (var entity in entities)
                            {
                                string entityname = entity.SchemaName.ToLower();
                                foreach (AttributeMetadata att in entity.Attributes)
                                {
                                    string attributename = att.SchemaName.ToLower();
                                    if (attributename == fieldname)
                                    {
                                        //Add the Entity the TreeView
                                        TreeNode parent = resultsTree.Nodes.Add(entityname);

                                        //Add Type
                                        resultsTree.Nodes[parent.Index].Nodes.Add("Type: " + att.AttributeType.Value.ToString());

                                        //Add FieldType
                                        if(att.SourceType != null)
                                        {
                                            int fieldtype = att.SourceType.Value;
                                            string fieldtype_label = "Simple";
                                            if (fieldtype == 0)
                                            {
                                                fieldtype_label = "Simple";
                                            }
                                            else if (fieldtype == 1)
                                            {
                                                fieldtype_label = "Calculated";
                                            }
                                            else if (fieldtype == 2)
                                            {
                                                fieldtype_label = "Rollup";
                                            }
                                            resultsTree.Nodes[parent.Index].Nodes.Add("Field Type: " + fieldtype_label);
                                        }
                                        
                                        //Add RequiredLevel
                                        if(att.RequiredLevel != null)
                                        {
                                            resultsTree.Nodes[parent.Index].Nodes.Add("Field Requirement: " + att.RequiredLevel.Value.ToString());
                                        }                                        

                                        //Add FieldSecurity
                                        if(att.IsSecured != null)
                                        {
                                            resultsTree.Nodes[parent.Index].Nodes.Add("Field Security: " + att.IsSecured.Value.ToString());
                                        }                                        

                                        //Add AuditStatus
                                        if(att.IsAuditEnabled != null)
                                        {
                                            resultsTree.Nodes[parent.Index].Nodes.Add("Audit Status: " + att.IsAuditEnabled.Value.ToString());
                                        }
                                        
                                        //Count up for an attribute
                                        counter++;
                                    }
                                }
                            }
                            fieldName.Text = fieldname;
                            fieldName.Refresh();
                            resultsTree.Refresh();

                            if(counter == 0)
                            {
                                MessageBox.Show("The field has no been found.",
                                "Field Not Found",
                                MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("The field \"" + fieldname + "\" has been found in " + counter + " entities.",
                                "Field Found",
                                MessageBoxButtons.OK);
                            }                            
                        }
                    }
                });
            }
            else
            {
                MessageBox.Show("Please enter a field name and restart searching.",
                "Field Missing",
                MessageBoxButtons.OK);
            }
        }
    }
}