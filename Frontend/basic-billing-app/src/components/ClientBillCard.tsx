import { Flex, Text } from '@chakra-ui/react';

const ClientBillCard = ({ id, status }: { id: number; status: string }) => {
  return (
    <Flex
      w={'100%'}
      h={'4rem'}
      p={'1rem'}
      bgColor={'gray.50'}
      justifyContent={'space-between'}
      alignItems={'center'}
      borderRadius={'md'}
      shadow={'md'}
      m={'0.5rem 0'}
      overflow={'hidden'}
      position={'relative'}
    >
      <Flex
        bgColor={'blue.100'}
        position={'absolute'}
        w={'0.5rem'}
        h={'100%'}
        left={0}
      />
      <Text>{`Bill #${id}`}</Text>
      <Text>{`Status: ${status}`}</Text>
    </Flex>
  );
};

export default ClientBillCard;
