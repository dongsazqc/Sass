using FaceGetTenant_CLB.Models;

namespace FaceGetTenant_CLB
{
    public CheckTenantModel GetTenant(string tenant_code)
    {
        try
        {
            var memberCheckin = new CheckTenantModel();
            var clientHelper = new HttpClientHelper<CheckTenantModel>();
            var url = string.Format("/tenant/validate-business-key/{0}", tenant_code);
            var wrap = clientHelper.Get(url);
            if (wrap != null)
            {
                memberCheckin = wrap;
                return memberCheckin;
            }
            else
            {
                MyAlert.ShowError("Có lỗi:" + clientHelper.ToString());
                return null;
            }

        }
        catch (Exception ez)
        {
            //LogUtils.SystemErrorLog("member_status_order:" + ez.ToString());
            MyAlert.ShowError(ez.ToString());
            return null;
        }
    }

}
