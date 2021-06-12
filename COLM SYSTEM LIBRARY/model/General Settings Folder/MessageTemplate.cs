﻿using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.General_Settings_Folder
{
    public class MessageTemplate
    {
        public int TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string TemplateSubject { get; set; }
        public string TemplateMessage { get; set; }
        public List<MessageAttachment> Attachments { get; set; } = new List<MessageAttachment>();



        public static int SaveMessageTemplate(MessageTemplate template)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    using (SqlCommand comm = new SqlCommand("INSERT INTO settings.email_message_templates VALUES (@TemplateName,@TemplateSubject,@TemplateMessage)", conn, t))
                    {
                        comm.Parameters.AddWithValue("@TemplateName", template.TemplateName);
                        comm.Parameters.AddWithValue("@TemplateSubject", template.TemplateSubject);
                        comm.Parameters.AddWithValue("@TemplateMessage", template.TemplateMessage);
                        comm.ExecuteNonQuery();
                    }

                    using (SqlCommand comm = new SqlCommand("SELECT TemplateID FROM settings.email_message_templates (NOLOCK) WHERE TemplateName = @TemplateName", conn, t))
                    {
                        comm.Parameters.AddWithValue("@TemplateName", template.TemplateName);
                        template.TemplateID = Convert.ToInt32(comm.ExecuteScalar());
                    }

                    foreach (var item in template.Attachments)
                    {
                        using (SqlCommand comm = new SqlCommand("INSERT INTO settings.email_message_template_attachments VALUES (@TemplateID,@Name,@FileType,@Attachment)", conn, t))
                        {
                            comm.Parameters.AddWithValue("@TemplateID", template.TemplateID);
                            comm.Parameters.AddWithValue("@Name", item.Name);
                            comm.Parameters.AddWithValue("@FileType", item.FileType);
                            comm.Parameters.Add("@Attachment",SqlDbType.Image);
                            comm.Parameters["@Attachment"].Value = item.Attachement;
                            comm.ExecuteNonQuery();
                        }
                    }

                    t.Commit();
                    return 1;
                }
            }
        }

        public static List<MessageTemplate> GetTemplates()
        {
            List<MessageTemplate> templates = new List<MessageTemplate>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                MessageTemplate template = new MessageTemplate();
                //get template information
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.email_message_templates", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            template.TemplateID = Convert.ToInt32(reader["TemplateID"]);
                            template.TemplateName = Convert.ToString(reader["TemplateName"]);
                            template.TemplateSubject = Convert.ToString(reader["TemplateSubject"]);
                            template.TemplateMessage = Convert.ToString(reader["TemplateMessage"]);
                        }
                    }
                }

                //get attachemnts;
                List<MessageAttachment> attachments = new List<MessageAttachment>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.email_message_template_attachments WHERE TemplateID = @TemplateID", conn))
                {
                    comm.Parameters.AddWithValue("@TemplateID",template.TemplateID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            attachments.Add(new MessageAttachment()
                            {
                                AttachmentID = Convert.ToInt32(reader["AttachmentID"]),
                                Name = Convert.ToString(reader["Name"]),
                                FileType = Convert.ToString(reader["FileType"]),
                                Attachement = (byte[])reader["Attachment"]
                            });
                        }
                    }
                }
                template.Attachments = attachments;
                templates.Add(template);
            }
            return templates;
        }

        public static MessageTemplate GetMessage(int TemplateID)
        {
            MessageTemplate template = new MessageTemplate();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                //get template information
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.email_message_templates WHERE TemplateID = @TemplateID", conn))
                {
                    comm.Parameters.AddWithValue("@TemplateID", TemplateID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            template.TemplateID = Convert.ToInt32(reader["TemplateID"]);
                            template.TemplateName = Convert.ToString(reader["TemplateName"]);
                            template.TemplateSubject = Convert.ToString(reader["TemplateSubject"]);
                            template.TemplateMessage = Convert.ToString(reader["TemplateMessage"]);
                        }
                    }
                }

                //get attachemnts;
                List<MessageAttachment> attachments = new List<MessageAttachment>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.email_message_template_attachments WHERE TemplateID = @TemplateID", conn))
                {
                    comm.Parameters.AddWithValue("@TemplateID", TemplateID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            attachments.Add(new MessageAttachment()
                            {
                                AttachmentID = Convert.ToInt32(reader["AttachmentID"]),
                                Name = Convert.ToString(reader["Name"]),
                                FileType = Convert.ToString(reader["FileType"]),
                                Attachement = (byte[])reader["Attachment"]
                            });
                        }
                    }

                }
                template.Attachments = attachments;
            }
            return template;
        }

        
    }
}
