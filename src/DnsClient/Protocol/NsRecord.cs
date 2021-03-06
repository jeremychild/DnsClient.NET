﻿using System;

namespace DnsClient.Protocol
{
    /*
    https://tools.ietf.org/html/rfc1035#section-3.3.11:
    NS RDATA format

        +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
        /                   NSDNAME                     /
        /                                               /
        +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

    where:

    NSDNAME         A <domain-name> which specifies a host which should be
                authoritative for the specified class and domain.

    NS records cause both the usual additional section processing to locate
    a type A record, and, when used in a referral, a special search of the
    zone in which they reside for glue information.

    The NS RR states that the named host should be expected to have a zone
    starting at owner name of the specified class.  Note that the class may
    not indicate the protocol family which should be used to communicate
    with the host, although it is typically a strong hint.  For example,
    hosts which are name servers for either Internet (IN) or Hesiod (HS)
    class information are normally queried using IN class protocols.
     */

    public class NsRecord : DnsResourceRecord
    {
        public DnsString NSDName { get; }

        public NsRecord(ResourceRecordInfo info, DnsString name)
            : base(info)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            NSDName = name;
        }

        public override string RecordToString()
        {
            return NSDName.Value;
        }
    }
}