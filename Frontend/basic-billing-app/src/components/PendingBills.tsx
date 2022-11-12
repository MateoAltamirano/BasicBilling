import {
  Button,
  Flex,
  FormControl,
  FormLabel,
  Input,
  useToast,
  Text,
} from '@chakra-ui/react';
import { useState } from 'react';
import { FiSearch } from 'react-icons/fi';
import { useBasicBillingStore } from '../utils/useBasicBillingStore';
import ClientBillCard from './ClientBillCard';
import { FiInbox, FiCreditCard } from 'react-icons/fi';

const PendingBills = () => {
  const [clientID, setClientID] = useState<string>('');
  const pendingBillsFromClient = useBasicBillingStore(
    (state) => state.pendingBillsFromClient
  );
  const fetchPendingBillsFromClient = useBasicBillingStore(
    (state) => state.fetchPendingBillsFromClient
  );

  const payBill = useBasicBillingStore((state) => state.payBill);

  const toast = useToast();

  const handlePendingBillsSearch = async () => {
    const errors = await fetchPendingBillsFromClient(clientID);
    if (errors) {
      toast({
        title: errors.type,
        description: errors.details.join(', '),
        status: 'error',
        duration: 3000,
      });
    }
  };

  const handleBillPayment = async (billID: string) => {
    const errors = await payBill(billID);
    if (errors) {
      toast({
        title: errors.type,
        description: errors.details.join(', '),
        status: 'error',
        duration: 3000,
      });
    }
  };

  return (
    <Flex h={'100%'} w={'100%'} flexDir={'column'} overflow={'auto'}>
      <FormControl mb={'0.5rem'}>
        <FormLabel>{'Enter the client ID please:'}</FormLabel>
        <Input
          color={'gray.800'}
          onChange={({ target }) => setClientID(target.value)}
          value={clientID}
          variant={'outline'}
        />
      </FormControl>
      <Button
        colorScheme={'twitter'}
        bgColor={'blue.400'}
        leftIcon={<FiSearch size={'1.25rem'} />}
        onClick={() => handlePendingBillsSearch()}
      >
        {'Search'}
      </Button>
      {pendingBillsFromClient.length > 0 ? (
        pendingBillsFromClient.map((bill) => (
          <Flex key={bill.id} alignItems={'center'} m={'0.5rem 0'}>
            <ClientBillCard key={bill.id} id={bill.id} status={bill.status} />
            <Button
              h={'100%'}
              ml={'1rem'}
              colorScheme={'whatsapp'}
              leftIcon={<FiCreditCard size={'1.25rem'} />}
              onClick={() => handleBillPayment(bill.id.toString())}
            >
              {'Pay'}
            </Button>
          </Flex>
        ))
      ) : (
        <Flex
          flexDir={'column'}
          h={'100%'}
          w={'100%'}
          justifyContent={'center'}
          alignItems={'center'}
        >
          <FiInbox size={'10rem'} color={'#CBD5E0'} />
          <Text fontSize={'1.5rem'} color={'#CBD5E0'}>
            {'No pending bills found'}
          </Text>
        </Flex>
      )}
    </Flex>
  );
};
export default PendingBills;
