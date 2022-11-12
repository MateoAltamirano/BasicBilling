import { Flex, Text } from '@chakra-ui/react';

const ClientBillCard = ({ id, status }: { id: number; status: string }) => {
  return (
    <Flex
      w={'100%'}
      p={'1rem'}
      justifyContent={'space-between'}
      bgColor={'blue.100'}
      borderRadius={'md'}
      shadow={'md'}
    >
      <Text>{`Bill #${id}`}</Text>
      <Text>{`Status: ${status}`}</Text>
    </Flex>
  );
};

export default ClientBillCard;
