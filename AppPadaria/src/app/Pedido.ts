export class Pedido {
    // armazena o id do pedido
    id: number = 0;
    // armazena a data e hor[ario do pedido
    datapedido: Date | undefined;
    // armazena o nome do cliente que fez o pedido
    nomepedido: string = '';
    // armazena o status atual do pedido
    status: string = '';
    // armazena o id do cliente que fez o pedido
    clienteid: number = 0;
    }