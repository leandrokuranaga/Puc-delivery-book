namespace deliverybook.Domain.Model.Spotify.Auth
{
    public class ClientCredentials
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}", ClientId, ClientSecret);
        }
    }
}