﻿namespace SCSS.Utilities.Constants
{
    public class NotificationMessage
    {
        public static string SellerCollectingRequestReceviedTitle => $"Yêu cầu thu gom của bạn đã được nhận";

        public static string SellerCollectingRequestReceviedBody(string collectingRequestCode) => $"Đã tìm thấy người thu gom cho yêu cầu thu gom {collectingRequestCode} của bạn";

        public static string CollectorCollectingRequestReceviedTitle => "Xác nhận thành công";

        public static string CollectorCollectingRequestReceviedBody(string code) => $"Bạn đã xác nhận yêu cầu thu gom {code} thành công";

        public static string CollectingRequestCancelTitle() => $"Yêu cầu thu gom của bạn đã bị hủy";

        public static string CollectingRequestCancelBody(string collectingRequestCode) => $"Yêu cầu thu gom {collectingRequestCode} của bạn đã bị hủy bởi người thu gom";

        public static string CancelCollectingRequestTitleSystem(string code) => $"Yêu cầu thu gom {code} đã bị hủy bởi hệ thống";

        public static string CancelCollectingRequestBodySystem(string code) => $"Yêu cầu thu gom {code} đã bị hủy bởi hệ thống. Chưa có người thu gom cho yêu cầu của bạn !";

        public static string CancelCRBySellerTitle => $"Yêu cầu thu gom đã bị hủy";

        public static string CancelCRBySellerBody(string code) => $"Bạn đã hủy yêu cầu thu gom {code}";

        public static string CancelCRBySellerToCollectorBody(string code) => $"Yêu cầu thu gom {code} đã bị hủy bởi người bán";

        public static string CancelCRByCollector(string code) => $"Yêu cầu thu gom {code} đã bị hủy bởi người thu gom";

        public static string CompletedSellerCRTitle => $"Giao dịch thu gom hoàn tất";

        public static string CompletedSellerCRBody(string code) => $"Giao dịch thu gom {code} của bạn đã hoàn tất. Hãy đánh giá trải nghiệm thua gom của bạn nhé";

        public static string CompletedCollectorCRBody(string code) => $"Giao dịch thu gom {code} của bạn đã hoàn tất.";

        public static string SystemCancelCRTitle => "Lịch hẹn đã bị hệ thống hủy";

        public static string SystemCancelCRSellerBody(string code, string date) => $"Lịch hẹn {code} vào lúc {date} đã bị hệ thống hủy";

        public static string SystemCancelCRCollectorBody(string code, string date) => $"Lịch hẹn {code} vào lúc {date} đã bị hệ thống hủy. Bởi vì bạn đã không tạo giao dịch hoàn tất lịch hẹn này";

        public static string SellerRequestCRTitle => "Tạo yêu cầu thu gom thành công";

        public static string SellerRequestCRBody(string code) => $"Yêu cầu thu gom {code} đã được tạo thành công. Hãy chờ người thu gom xác nhận đơn hàng";

        public static string CollectorReminderTitle(string code) => $"Yêu cầu thu gom {code} của bạn sắp đến";

        public static string CollectorReminderBody(string code, string addressName) => $"Yêu cầu thu gom {code} sắp đến, lịch hẹn thu gom ở {addressName}.";

        public static string RequestGoNowTitle => "Yêu cầu thu gom đến ngay";

        public static string RequestAppointmentTitle => "Yêu cầu thu gom đặt hẹn";

        public static string RequestAppointmentBody => "Có một yêu cầu thu gom đặt hẹn ở gần bạn.";

        public static string RequestGoNowBody => "Có một yêu cầu thu gom mới ở gần bạn.";




        public static string CompletedCollectDealTransCollectorTitle => $"Giao dịch bán cho vựa hoàn tất";

        public static string CompletedCollectDealTransCollectorBody(string code) => $"Giao dịch bán {code} của bạn đã hoàn tất. Hãy đánh giá trải nghiệm bán cho vựa của bạn nhé";


        public static string CompletedCollectDealTransDealerTitle => $"Giao dịch thu gom hoàn tất";

        public static string CompletedCollectDealTransDealerBody(string code) => $"Giao dịch thu gom {code} của bạn đã hoàn tất. Hãy đánh giá trải nghiệm thu gom của bạn nhé";

    }
}
