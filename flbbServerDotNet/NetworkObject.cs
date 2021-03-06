using LiteNetLib;
using LiteNetLib.Utils;

namespace flbbServerDotNet
{
    public class NetworkObject
    {
        public NetPeer peer;
        public int playerId;
        public int objectId;
        public int objectType;
        public float posX;
        public float posY;
        public float posZ;
        public float rotX;
        public float rotY;
        public float rotZ;
        public float rotW;
        private byte[] extraData = new byte[0];


        public NetworkObject(NetPeer peer, int objectType, int objectId, int playerId, float posX, float posY,
            float posZ, float rotX, float rotY, float rotZ, float rotW)
        {
            this.peer = peer;
            this.playerId = playerId;
            this.objectId = objectId;
            this.objectType = objectType;
            this.posX = posX;
            this.posY = posY;
            this.posZ = posZ;
            this.rotX = rotX;
            this.rotY = rotY;
            this.rotZ = rotZ;
            this.rotW = rotW;
        }

        public void WriteData(NetDataWriter writer)
        {
            writer.Put((ushort) 103);
            writer.Put(objectId);
            writer.Put(posX);
            writer.Put(posY);
            writer.Put(posZ);
            writer.Put(rotX);
            writer.Put(rotY);
            writer.Put(rotZ);
            writer.Put(rotW);
            if (extraData.Length > 0)
                writer.Put(extraData);
        }

        public void ReadData(NetDataReader reader)
        {
            posX = reader.GetFloat();
            posY = reader.GetFloat();
            posZ = reader.GetFloat();
            rotX = reader.GetFloat();
            rotY = reader.GetFloat();
            rotZ = reader.GetFloat();
            rotW = reader.GetFloat();
            if (!reader.EndOfData)
            {
                extraData = reader.GetRemainingBytes();
            }
        }

        public void SendObjectData(NetDataWriter writer)
        {
            writer.Put((ushort) 101);
            writer.Put(objectType);
            writer.Put(objectId);
            writer.Put(playerId);
            writer.Put(peer.Id);
            writer.Put(posX);
            writer.Put(posY);
            writer.Put(posZ);
            writer.Put(rotX);
            writer.Put(rotY);
            writer.Put(rotZ);
            writer.Put(rotW);
        }
    }
}