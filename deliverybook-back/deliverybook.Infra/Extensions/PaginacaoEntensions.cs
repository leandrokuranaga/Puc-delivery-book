namespace deliverybook.Infra.Extensions
{
    public static class PaginacaoEntensions
    {
        private const int _default = 0;
        private const int _fisrt = 1;
        private const int _limit = 10;

        public static int CalcularOffset(this int pagina)
        {
            if (int.Equals(_default, pagina) || int.Equals(_fisrt, pagina))
                return _default;

            return (pagina - 1) * _limit;
        }

        public static int CalcularPagina(this int offset)
        {
            if (int.Equals(_default, offset) || int.Equals(_fisrt, offset))
                return _fisrt;

            return (offset / _limit) + 1;
        }
    }
}