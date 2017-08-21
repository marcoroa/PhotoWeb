using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhotoRequests.com.homesusa.dev;
using System.Web.UI.HtmlControls;

namespace PhotoRequests
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            PhotoRequestServiceSoapClient service = new PhotoRequestServiceSoapClient();
            var userDetails = new UserDetails()
            {
                //userName = "mroa",//username.Text,
                //password = "hUSA2015"//password.Text
                userName = "mhiphotostatus",
                password = "hu$a2017!"
            };

            var specificResult = service.GetPhotoRequest(userDetails, 9356);
            RenderSpecificResult(specificResult, "Photo Request");

            specificResult = service.GetPhotoRequest(userDetails, 9497);
            RenderSpecificResult(specificResult, "Photo Request");

            var response = service.GetProcessingPhotoRequests(userDetails);
            RenderResults(response, "ProcessingPhotoRequests");

            response = service.GetAssignedPhotoRequests(userDetails);
            RenderResults(response, "AssignedPhotoRequests");

            response = service.GetAwaitingApprovalPhotoRequests(userDetails);
            RenderResults(response, "AwaitingApprovalPhotoRequests");

            response = service.GetAwaitingPreApprovalPhotoRequests(userDetails);
            RenderResults(response, "AwaitingPreApprovalPhotoRequests");

            response = service.GetCompletedPhotoRequests(userDetails);
            RenderResults(response, "CompletedPhotoRequests");

            response = service.GetPendingPhotoRequests(userDetails);
            RenderResults(response, "PendingPhotoRequests");

            response = service.GetPhotosRejectedPhotoRequests(userDetails);
            RenderResults(response, "PhotosRejectedPhotoRequests");

            response = service.GetRejectedPhotoRequests(userDetails);
            RenderResults(response, "RejectedPhotoRequests");
        }

        public void RenderSpecificResult(ServiceCallResponse response, string methodName)
        {
            var photoRequest = (PhotoServiceResponse)response.Data;
            if (photoRequest != null)
            {
                var h2 = new HtmlGenericControl("h2");
                h2.InnerHtml = methodName + " " + photoRequest.Address;
                container.Controls.Add(h2);

                Table tbl = new Table();
                tbl.ID = methodName;
                tbl.CssClass = "results-table";
                BuildTableHeader(tbl);

                #region BodyRows
                TableRow row = new TableRow();
                tbl.Rows.Add(row);
                row.Cells.Add(new TableCell() { Text = photoRequest.PhotoRequestID.ToString() });
                row.Cells.Add(new TableCell() { Text = photoRequest.PhotoRequestGUID.ToString() });
                row.Cells.Add(new TableCell() { Text = photoRequest.Address });
                row.Cells.Add(new TableCell() { Text = photoRequest.AddVirtualTour.HasValue ? photoRequest.AddVirtualTour.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.AssignedOn.HasValue ? photoRequest.AssignedOn.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.Assistant });
                row.Cells.Add(new TableCell() { Text = photoRequest.BuilderName });
                row.Cells.Add(new TableCell() { Text = photoRequest.City });

                row.Cells.Add(new TableCell() { Text = photoRequest.CommunityName });
                row.Cells.Add(new TableCell() { Text = photoRequest.CompletedBy != null ? photoRequest.CompletedBy.FullName : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.ContactDate.HasValue ? photoRequest.ContactDate.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.CreatedBy != null ? photoRequest.CreatedBy.FullName : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.Directions });
                row.Cells.Add(new TableCell() { Text = photoRequest.Email });
                row.Cells.Add(new TableCell() { Text = photoRequest.EmailPhoto });
                row.Cells.Add(new TableCell() { Text = photoRequest.JobName });
                row.Cells.Add(new TableCell() { Text = photoRequest.KeyAt });
                row.Cells.Add(new TableCell() { Text = photoRequest.Mobile });

                row.Cells.Add(new TableCell() { Text = photoRequest.ModifiedBy != null ? photoRequest.ModifiedBy.FullName : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.OnsitePersonName });
                row.Cells.Add(new TableCell() { Text = photoRequest.Phone });
                row.Cells.Add(new TableCell() { Text = photoRequest.Photographer != null ? photoRequest.Photographer.FullName : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.ScheduleDate.HasValue ? photoRequest.ScheduleDate.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.SlideShow.HasValue ? photoRequest.SlideShow.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.SpecialNotes });
                row.Cells.Add(new TableCell() { Text = photoRequest.SysCompletedOn.HasValue ? photoRequest.SysCompletedOn.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.SysCreatedOn.HasValue ? photoRequest.SysCreatedOn.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.SysDiscriminator });

                row.Cells.Add(new TableCell() { Text = photoRequest.SysModifiedOn.HasValue ? photoRequest.SysModifiedOn.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.SysOwnedBy.HasValue ? photoRequest.SysOwnedBy.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.SysState.HasValue ? photoRequest.SysState.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.SysStatusID.HasValue ? photoRequest.SysStatusID.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.SysTimestamp.HasValue ? photoRequest.SysTimestamp.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.Type.ToString() });
                row.Cells.Add(new TableCell() { Text = photoRequest.WideAngleLens.HasValue ? photoRequest.WideAngleLens.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.Zip.HasValue ? photoRequest.Zip.ToString() : string.Empty });
                row.Cells.Add(new TableCell() { Text = photoRequest.HighResolutionUrl });
                #endregion

                container.Controls.Add(tbl);
            }
        }

        public void RenderResults(ServiceCallResponse response, string methodName)
        {
            var collection = (PhotoServiceResponse[])response.Data;
            if (collection.Count() > 0)
            {
                var h2 = new HtmlGenericControl("h2");
                h2.InnerHtml = methodName;
                container.Controls.Add(h2);

                Table tbl = new Table();
                tbl.ID = methodName;
                tbl.CssClass = "results-table";
                BuildTableHeader(tbl);

                #region BodyRows
                foreach (var pr in collection)
                {
                    TableRow row = new TableRow();
                    tbl.Rows.Add(row);
                    row.Cells.Add(new TableCell() { Text = pr.PhotoRequestID.ToString(), CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.PhotoRequestGUID.ToString(), CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.Address, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.AddVirtualTour.HasValue ? pr.AddVirtualTour.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.AssignedOn.HasValue ? pr.AssignedOn.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.Assistant, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.BuilderName, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.City, CssClass = "cell" });

                    row.Cells.Add(new TableCell() { Text = pr.CommunityName, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.CompletedBy != null ? pr.CompletedBy.FullName : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.ContactDate.HasValue ? pr.ContactDate.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.CreatedBy != null ? pr.CreatedBy.FullName : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.Directions, CssClass = "cell-large" });
                    row.Cells.Add(new TableCell() { Text = pr.Email, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.EmailPhoto, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.JobName, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.KeyAt, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.Mobile, CssClass = "cell" });

                    row.Cells.Add(new TableCell() { Text = pr.ModifiedBy != null ? pr.ModifiedBy.FullName : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.OnsitePersonName, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.Phone, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.Photographer != null ? pr.Photographer.FullName : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.ScheduleDate.HasValue ? pr.ScheduleDate.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.SlideShow.HasValue ? pr.SlideShow.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.SpecialNotes, CssClass = "cell-large" });
                    row.Cells.Add(new TableCell() { Text = pr.SysCompletedOn.HasValue ? pr.SysCompletedOn.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.SysCreatedOn.HasValue ? pr.SysCreatedOn.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.SysDiscriminator, CssClass = "cell" });

                    row.Cells.Add(new TableCell() { Text = pr.SysModifiedOn.HasValue ? pr.SysModifiedOn.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.SysOwnedBy.HasValue ? pr.SysOwnedBy.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.SysState.HasValue ? pr.SysState.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.SysStatusID.HasValue ? pr.SysStatusID.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.SysTimestamp.HasValue ? pr.SysTimestamp.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.Type.ToString(), CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.WideAngleLens.HasValue ? pr.WideAngleLens.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.Zip.HasValue ? pr.Zip.ToString() : string.Empty, CssClass = "cell" });
                    row.Cells.Add(new TableCell() { Text = pr.HighResolutionUrl, CssClass = "cell" });
                }
                #endregion

                container.Controls.Add(tbl);
            }
        }

        public void BuildTableHeader(Table tbl)
        {

            #region HeaderRow
            TableHeaderRow thr = new TableHeaderRow();
            thr.TableSection = TableRowSection.TableHeader;
            thr.Cells.Add(new TableHeaderCell() { Text = "PhotoRequestID", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "PhotoRequestGUID", CssClass = "cell-large" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Address", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "AddVirtualTour", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "AssignedOn", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Assistant", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "BuilderName", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "City", CssClass = "cell" });

            thr.Cells.Add(new TableHeaderCell() { Text = "CommunityName", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "CompletedBy", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "ContactDate", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "CreatedBy", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Directions", CssClass = "cell-huge" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Email", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "EmailPhoto", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "JobName", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "KeyAt", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Mobile", CssClass = "cell" });

            thr.Cells.Add(new TableHeaderCell() { Text = "ModifiedBy", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "OnsitePersonName", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Phone", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Photographer", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "ScheduleDate", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SlideShow", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SpecialNotes", CssClass = "cell-huge" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SysCompletedOn", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SysCreatedOn", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SysDiscriminator", CssClass = "cell" });

            thr.Cells.Add(new TableHeaderCell() { Text = "SysModifiedOn", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SysOwnedBy", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SysState", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SysStatusID", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "SysTimestamp", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Type", CssClass = "cell-medium" });
            thr.Cells.Add(new TableHeaderCell() { Text = "WideAngleLens", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "Zip", CssClass = "cell" });
            thr.Cells.Add(new TableHeaderCell() { Text = "HighResolutionUrl", CssClass = "cell-huge" });

            tbl.Rows.Add(thr);
            #endregion
        }
    }
}