FROM mono:5.8

WORKDIR /root
ADD client.cs .

RUN nuget install WampSharp.Default.Client

RUN find /root/ | grep -i wamp

# FIXME: https://gist.github.com/oberstet/d46d1eb9bbfeef1f85fa2e2ab9642f7d
RUN mono-csc \
    -r:System.Reactive.Interfaces \
    -r:/root/WampSharp.18.3.2/lib/net45/WampSharp.dll \
    -r:/root/WampSharp.Default.Client.18.3.2/lib/net45/WampSharp.Default.Client.dll \
    client.cs

CMD ["mono", "/root/client.exe"]
